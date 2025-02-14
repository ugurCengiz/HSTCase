using Entities.Concrete;
using HST.Case.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HST.Case.Web.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration, HttpClient httpClient = null)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
        }

        public async Task<IActionResult> Index()
        {
            string url = "api/Products/GetList";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            string jsonData = await response.Content.ReadAsStringAsync();

            var productList = JsonConvert.DeserializeObject<List<Product>>(jsonData);

            return View(productList);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, string email)
        {
            string url = "api/Products/GetList";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            string jsonData = await response.Content.ReadAsStringAsync();

            var productList = JsonConvert.DeserializeObject<List<Product>>(jsonData);

            var product = productList.FirstOrDefault(p => p.Id == productId);
            if (product == null) return NotFound();

            var basket = HttpContext.Session.GetObject<BasketModel>("Basket") ?? new BasketModel();

            if (string.IsNullOrEmpty(basket.Email))
            {
                if (string.IsNullOrEmpty(email))
                {
                    TempData["RequireEmail"] = true;
                    return RedirectToAction("Index");
                }
                basket.Email = email;
            }

            var basketItem = basket.Items.FirstOrDefault(i => i.ProductId == productId);
            if (basketItem != null)
            {
                basketItem.Quantity++;
            }
            else
            {
                basket.Items.Add(new BasketItemModel
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetObject("Basket", basket);
            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {
            var basket = HttpContext.Session.GetObject<BasketModel>("Basket") ?? new BasketModel();
            return View(basket);
        }
        [HttpPost]
        public IActionResult UpdateQuantity(int productId, string action)
        {
            var basket = HttpContext.Session.GetObject<BasketModel>("Basket") ?? new BasketModel();

            var item = basket.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                if (action == "increase")
                {
                    item.Quantity++;
                }
                else if (action == "decrease" && item.Quantity > 1)
                {
                    item.Quantity--;
                }
            }

            HttpContext.Session.SetObject("Basket", basket); 

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult RemoveItem(int productId)
        {
            var basket = HttpContext.Session.GetObject<BasketModel>("Basket") ?? new BasketModel();

            var item = basket.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                basket.Items.Remove(item);
            }

            HttpContext.Session.SetObject("Basket", basket);  

            return RedirectToAction("Cart");
        }
    }
}
