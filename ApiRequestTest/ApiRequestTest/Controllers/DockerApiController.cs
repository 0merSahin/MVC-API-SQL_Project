using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiRequestTest.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiRequestTest.Controllers
{
    public class DockerApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DockerApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string dockerApiUrl = "http://web-api:80/api/product";

            try
            {
                var result = await SendHttpGetRequest(dockerApiUrl);
                var model = JsonConvert.DeserializeObject<List<Product>>(result);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        private async Task<string> SendHttpGetRequest(string apiUrl)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }



        //------------------------------------------------------------------------------------


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string dockerApiUrl = "http://web-api:80/api/product";

                try
                {
                    string jsonProduct = JsonConvert.SerializeObject(product);
                    await SendHttpPostRequest(dockerApiUrl, jsonProduct);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }

            return View(product);
        }

        private async Task<string> SendHttpPostRequest(string apiUrl, string jsonContent)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }


    }
}

