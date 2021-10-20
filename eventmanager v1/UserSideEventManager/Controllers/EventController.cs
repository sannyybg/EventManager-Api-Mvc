using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserSideEventManager.Models;
using X.PagedList;

namespace UserSideEventManager.Controllers
{
    public class EventController : Controller
    {

        private HttpClient client = new HttpClient();

        public async Task<IActionResult> AllEvents(int? page)
        {
            var url = "https://localhost:44357/api/v1/Event?id=0";

            var response = await client.GetAsync(url);
            var allevents = JsonConvert.DeserializeObject<List<Event>>(await response.Content.ReadAsStringAsync());

            var pagenumber = page ?? 1;
            var pagesize = 4;
            var eventsonpage = allevents.ToPagedList(pagenumber, pagesize);

            return View(eventsonpage);
        }

        public async Task<IActionResult> FinishedEvents()
        {
            var url = "https://localhost:44357/api/v1/Event/GetFinishedEvents";

            var response = await client.GetAsync(url);
            var allevents = JsonConvert.DeserializeObject<List<Event>>(await response.Content.ReadAsStringAsync());
            return View(allevents);
        }

        [Authorize]
        public async Task<IActionResult> UserEvents(int? page)
        {
            var id = User.Identity.Name;

            var url = $"https://localhost:44357/api/v1/Event/GetUserIdAsync?userid={id}";

            var jwttoken = HttpContext.Request.Cookies["apitoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwttoken);

            var response = await client.GetAsync(url);
            var allevents = JsonConvert.DeserializeObject<List<Event>>(await response.Content.ReadAsStringAsync());

            var pagenumber = page ?? 1;
            var pagesize = 10;
            var eventsonpage = allevents.ToPagedList(pagenumber, pagesize);
            return View(eventsonpage);
        }



        public async Task<IActionResult> Details(int id)
        {
            var url = $"https://localhost:44357/api/v1/Event?id={id}";


            var response = await client.GetAsync(url);
            var ev = JsonConvert.DeserializeObject<Event>(await response.Content.ReadAsStringAsync());
            return View(ev);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var url = $"https://localhost:44357/api/v1/Event?id={id}";

            var jwttoken = HttpContext.Request.Cookies["apitoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwttoken);

            var response = await client.GetAsync(url);
            var ev = JsonConvert.DeserializeObject<Event>(await response.Content.ReadAsStringAsync());
            if(ev.UserId.ToString() == User.Identity.Name)
            {
                return View(ev);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EventEditModel model)
        {
            model.UserId = Int32.Parse(User.Identity.Name);
            var url = $"https://localhost:44357/api/v1/Event";

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var jwttoken = HttpContext.Request.Cookies["apitoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwttoken);

            await client.PutAsync(url, data);

            return RedirectToAction("UserEvents");
        }


        [Authorize]
        public IActionResult Create()
        {
         
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(EventPostRequest model)
        {
            model.UserId = Int32.Parse(User.Identity.Name);

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:44357/api/v1/Event";

            var jwttoken = HttpContext.Request.Cookies["apitoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwttoken);

            var response = await client.PostAsync(url, data);


            return RedirectToAction("UserEvents");
        }


    }
}