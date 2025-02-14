using Business.Features.Orders.Queries.GetList;
using Entities.Concrete;
using HST.Case.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HST.Case.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OrdersController(IConfiguration configuration, HttpClient httpClient = null)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
        }
        public async Task< IActionResult> Index()
        {
            string url = "api/Orders/GetList";

            HttpResponseMessage response = await _httpClient.GetAsync(url);



            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            string jsonData = await response.Content.ReadAsStringAsync();

            var productList = JsonConvert.DeserializeObject<List<GetListOrderDto>>(jsonData);

            return View(productList);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderModel model)
        {

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/Orders/Update", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
