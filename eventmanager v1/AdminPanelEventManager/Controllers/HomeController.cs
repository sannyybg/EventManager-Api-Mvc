using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdminPanelEventManager.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminPanelEventManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var url = "https://localhost:44371/apihealth";

            var response = await client.GetAsync(url);
            var xx = await response.Content.ReadAsStringAsync();

            var checkedlist = ParseJson(xx);

            return View(checkedlist);

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


        public List<HealthCheckViewModel> ParseJson(string json)
        {
            JObject jsonn = JObject.Parse(json);
            var hcheckList = new List<HealthCheckViewModel>();

            for (var i = 1; i <= 15; i++)
            {
                var healtcheck = new HealthCheckViewModel();
                healtcheck.Duration = jsonn["entries"][$"{i}"]["duration"].ToString();
                healtcheck.Status = jsonn["entries"][$"{i}"]["status"].ToString();
                var xxv = jsonn["entries"][$"{i}"]["tags"].ToString();
                healtcheck.Tags = jsonn["entries"][$"{i}"]["tags"].ToArray()[0].ToString();
                hcheckList.Add(healtcheck);

            }
            hcheckList[7].Status = "Degraded";

            return hcheckList;
        }
    }
}
