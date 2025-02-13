using HST.Case.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HST.Case.Web.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PaymentsController(IConfiguration configuration, HttpClient httpClient = null)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
        }
        public async Task<IActionResult> Index()
        {
            var basket = HttpContext.Session.GetObject<BasketModel>("Basket") ?? new BasketModel();
            if (basket == null || !basket.Items.Any())
            {
                return RedirectToAction("Index", "Home");
            }

            string url = $"api/Campaings/GetAvailableInstallments/{basket.TotalPrice}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            string jsonData = await response.Content.ReadAsStringAsync();

            var availableInstallments = JsonConvert.DeserializeObject<List<int>>(jsonData);

            var model = new CheckoutViewModel
            {
                TotalAmount = basket.TotalPrice,
                AvailableInstallments = availableInstallments
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Checkout(PaymentViewModel model)
        {
            var basket = HttpContext.Session.GetObject<BasketModel>("Basket") ?? new BasketModel();
            if (basket == null || !basket.Items.Any())
            {
                return RedirectToAction("Index", "Home");
            }
            OrderModel orderModel = new OrderModel
            {
                Basket = basket,
                Email = basket.Email,
                selectedInstallment = model.Installment
            };



            var content = new StringContent(JsonConvert.SerializeObject(orderModel), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Orders/CreateOrder", content);

            if (!response.IsSuccessStatusCode)
            {

            }
            string jsonData = await response.Content.ReadAsStringAsync();
            var orderCreatedViewModel = JsonConvert.DeserializeObject<OrderCreatedViewModel>(jsonData);

            model.OrderId = orderCreatedViewModel.OrderId;

            var paymentContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var paymentResponse = await _httpClient.PostAsync("api/Payments/ProcessPayment", paymentContent);
            if (!paymentResponse.IsSuccessStatusCode)
            {

            }
            HttpContext.Session.Remove("Basket");
            return RedirectToAction("Index", "Home");
        }
    }
}
