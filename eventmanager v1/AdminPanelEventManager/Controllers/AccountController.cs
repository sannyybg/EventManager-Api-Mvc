using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdminPanelEventManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminPanelEventManager.Controllers
{
    public class AccountController : Controller
    {

        private HttpClient client = new HttpClient();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:44357/api/v1/User/CheckLogin";
            

            var response = await client.PostAsync(url, data);
            User existinguser = new User();
            try
            {
                existinguser = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }
            catch
            {
                return RedirectToAction();
            }

            if (existinguser.isAdmin)
            {
                var nameClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, existinguser.FirstName)
                };

                var loginClaims = new ClaimsIdentity(nameClaims, "ForIdentity");
                var userPrincipal = new ClaimsPrincipal(new[] { loginClaims });

                await HttpContext.SignInAsync(userPrincipal);

            }
            Response.Cookies.Append("apitoken", existinguser.Token);
            return RedirectToAction("index", "Home");

        }

        [Authorize]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequest newuser)
        {
            var json = JsonConvert.SerializeObject(newuser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:44357/api/v1/User/Register";

            var response = await client.PostAsync(url, data);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("GetUsers");
            }
            else
            {
                return Content("Invalid Inputs");
            }
            
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Append("apitoken", "");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var url = "https://localhost:44357/api/v1/User";

            var jwttoken = HttpContext.Request.Cookies["apitoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwttoken);

            var response = await client.GetAsync(url);

            var allusers = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
            return View(allusers);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var url = $"https://localhost:44357/api/v1/User?id={id}";

            var jwttoken = HttpContext.Request.Cookies["apitoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwttoken);

            var response = await client.DeleteAsync(url);
            return RedirectToAction("GetUsers");
        }

    }
}