using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagerAPI.Models;
using EventManagerAPI.Resources;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class EventController : ControllerBase
    {

        private IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }


        
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int id=0)
        {
            if (id == 0)
            {
                var result = await _service.GetAll();
                return Ok(result.Adapt<List<EventDTO>>());
            }
            else
            {
                var result = await _service.GetAsyncWithId(id);
                return Ok(result.Adapt<EventDTO>());
            }
            
        }

        [MapToApiVersion("1.0")]
        [Route("GetEventAll")]
        [HttpGet]
        public async Task<IActionResult> GetEventAll()
        {

            var result = await _service.GetEvents();
            return Ok(result.Adapt<List<EventDTO>>());

        }

        [MapToApiVersion("1.0")]
        [Route("GetFinishedEvents")]
        [HttpGet]
        public async Task<IActionResult> GetFinishedEvents()
        {

            var result = await _service.GetFinishedEvents();
            return Ok(result.Adapt<List<EventDTO>>());

        }

        [Authorize]
        [MapToApiVersion("1.0")]
        [HttpPut]
        public async Task Update(EventPutRequest evt)
        { 
            var xx = evt.Adapt<EventServiceModel>();
            await _service.Update(xx);

        }

        [Authorize(Roles ="Admin")]
        [MapToApiVersion("1.0")]
        [Route("UpdateAdmin")]
        [HttpPut]
        public async Task UpdateAdmin(EventAdminPut evt)
        {

            await _service.UpdateAdmin(evt.Id, evt.isPublished, evt.ModifiedDate, evt.UserId);

        }

        [Authorize]
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task Create(EventRequest evt)
        {
            var xx = evt.Adapt<EventServiceModel>();
            await _service.AddAsync(xx);

        }

        [Authorize(Roles ="User")]
        [MapToApiVersion("1.0")]
        [Route("GetUserIdAsync")]
        //[HttpGet("{userid}")]
        [HttpGet]
        public async Task<IActionResult> GetUserIdAsync(int userid)
        {
            var iclaim = User.Claims.FirstOrDefault(x => x.Type.Equals("id", StringComparison.InvariantCultureIgnoreCase));

            if (userid.ToString() == iclaim.Value)
            {
                var xx = await _service.GetAsync(userid);

                return Ok(xx.Adapt<List<EventDTO>>());
            }
            else
            {
                return BadRequest();
            }
            

        }


    

        [MapToApiVersion("1.0")]
        [Route("CheckEventDates")]
        [HttpPost]
        public async Task CheckEventDates()
        {
            await _service.CheckEventDates();
        }














        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetAll2()
        {
            
            return NotFound(Messages.NotFound);

        }
    }
}