using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagerAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Models;

namespace EventManagerAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        
        public UserController(IUserService service)
        {
            _service = service;
        }

        [MapToApiVersion("1.0")]
        [Route("CheckLogin")]
        [HttpPost]
        public async Task<UserDTO> CheckUserExists(UserLoginRequestModel user)
        {
            var xx = await _service.GetAsync(user.Username, user.Password);
            var existinguser = xx.Adapt<UserDTO>();
            if (existinguser != null)
            {
                return existinguser;
            }
            else
            {
                return new UserDTO();
            }

        }

        [MapToApiVersion("1.0")]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserRequest newuser)
        {
            var user = newuser.Adapt<UserServiceModel>();
            await _service.AddAsync(user);
            return Ok();

        }

    
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<List<UserDTO>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return result.Adapt<List<UserDTO>>();

        }

        [Authorize(Roles = "Admin")]
        [MapToApiVersion("1.0")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();

        }
    }
}