using Entities.Concrete;
using HST.Case.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HST.Case.Web.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration, HttpClient httpClient = null)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
        }
        public async Task< IActionResult> GetProduct()
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
        public async Task<IActionResult> Add(AddProductModel model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Products/Add", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction(nameof(GetProduct));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductModel model)
        {

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/Products/Update", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction(nameof(GetProduct));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _httpClient.DeleteAsync($"api/Products/Delete/{id}");


            return RedirectToAction(nameof(GetProduct));
        }
    }
}
