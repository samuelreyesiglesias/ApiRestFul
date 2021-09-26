using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UI.WebApiClient.Models;

namespace UI.WebApiClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            //consuming the api.

            
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44351/Api/Simplest/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage Response = await Client.GetAsync("Index"); 
            string StringResult = "";


            if (Response.IsSuccessStatusCode)
            {
               StringResult= Response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                StringResult = "Error getting the data";
            }
            return View(model:StringResult);
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
