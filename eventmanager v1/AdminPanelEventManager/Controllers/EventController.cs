using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AdminPanelEventManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;
using X.PagedList.Web.Common;
using X.PagedList.Mvc.Core;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace AdminPanelEventManager.Controllers
{
    public class EventController : Controller
    {
        private HttpClient client = new HttpClient();

        private readonly string _apiurl = "https://localhost:44357/api/v1/Event";




        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetEvents(int? page)
        {

            var url = $"{_apiurl}/GetEventAll";

            var jwttoken = HttpContext.Request.Cookies["apitoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwttoken);

            var response = await client.GetAsync(url);
            var allevents = JsonConvert.DeserializeObject<List<Event>>(await response.Content.ReadAsStringAsync());

            var pagenumber = page ?? 1;
            int pagesize = 10;
            var eventsonpage = allevents.ToPagedList(pagenumber, pagesize);
            return View(eventsonpage);

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
 
            var url = $"{_apiurl}?id={id}";

            var jwttoken = HttpContext.Request.Cookies["apitoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwttoken);

            var response = await client.GetAsync(url);
            var ev = JsonConvert.DeserializeObject<Event>(await response.Content.ReadAsStringAsync());
            return View(ev);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EventEditModel edit)
        {
            var url = $"{_apiurl}/UpdateAdmin";

            var jwttoken = HttpContext.Request.Cookies["apitoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwttoken);

            var json = JsonConvert.SerializeObject(edit);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PutAsync(url, data);
            
            return RedirectToAction("GetEvents");

        }
    }
}