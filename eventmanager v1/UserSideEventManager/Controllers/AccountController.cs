using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using UserSideEventManager.Models;

namespace UserSideEventManager.Controllers
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
            
            if (existinguser.Id != 0 && !existinguser.isAdmin)
            {
                var nameClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, existinguser.Id.ToString())
                };

                var loginClaims = new ClaimsIdentity(nameClaims, "ForIdentity");
                var userPrincipal = new ClaimsPrincipal(new[] { loginClaims });

                await HttpContext.SignInAsync(userPrincipal);

            }
            Response.Cookies.Append("apitoken", existinguser.Token);
            return RedirectToAction("Index", "Home");

        }





        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequest newuser)
        {
            var json = JsonConvert.SerializeObject(newuser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:44357/api/v1/User/Register";

            var response = await client.PostAsync(url, data);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Login");
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
    }
}