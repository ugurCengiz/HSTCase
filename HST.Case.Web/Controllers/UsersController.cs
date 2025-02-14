using Core.Entities.Concrete;
using Entities.Concrete;
using HST.Case.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HST.Case.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration, HttpClient httpClient = null)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
        }
        public async Task< IActionResult> GetUser()
        {
            string url = "api/Users/GetList";

            HttpResponseMessage response = await _httpClient.GetAsync(url);



            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            string jsonData = await response.Content.ReadAsStringAsync();

            var productList = JsonConvert.DeserializeObject<List<GetListUsersDto>>(jsonData);


            return View(productList);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserModel model)
        {

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/Users/Update", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction(nameof(GetUser));
        }
      
    }
}
