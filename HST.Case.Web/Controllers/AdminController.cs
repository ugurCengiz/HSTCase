using Entities.Concrete;
using HST.Case.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HST.Case.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration, HttpClient httpClient = null)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
        }
        public async Task<IActionResult> GetCampaign()
        {

            string url = "api/Campaings/GetList";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            string jsonData = await response.Content.ReadAsStringAsync();

            var productList = JsonConvert.DeserializeObject<List<Campaing>>(jsonData);

            return View(productList);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCampaignModel model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Campaings/Add", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction(nameof(GetCampaign));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCampaignModel model)
        {

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/Campaings/Update", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction(nameof(GetCampaign));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _httpClient.DeleteAsync($"api/Campaings/Delete/{id}");


            return RedirectToAction(nameof(GetCampaign));
        }
    }
}
