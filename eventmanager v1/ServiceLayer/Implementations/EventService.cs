using EventManager.Data.Abstractions;
using EventManager.Domain.POCO;
using Mapster;
using ServiceLayer.Abstractions;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class EventService : IEventService
    {
        private IEventRepository _repo;
        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }
        

        public async Task<List<EventServiceModel>> GetAll()
        {
            var xx = await _repo.GetAllAsync();
            return xx.Adapt<List<EventServiceModel>>();
        }

        public async Task Update(EventServiceModel evt)
        {
            var updatedevent = evt.Adapt<Event>();
            await _repo.Update(updatedevent);

        }

        public async Task AddAsync(EventServiceModel evt)
        {
            var updatedevent = evt.Adapt<Event>();
            await _repo.CreateAsync(updatedevent);

        }

        public async Task<List<EventServiceModel>> GetAsync(int id)
        {
            var evt = await _repo.GetAsync(id);
            return evt.Adapt<List<EventServiceModel>>();
        }

        public async Task<List<EventServiceModel>> GetEvents()
        {
            var xx = await _repo.GetEvents();
            return xx.Adapt<List<EventServiceModel>>();
        }

        public async Task<List<EventServiceModel>> GetFinishedEvents()
        {
            var xx = await _repo.GetFinishedEvents();
            return xx.Adapt<List<EventServiceModel>>();
        }

        public async Task CheckEventDates()
        {
            await _repo.CheckEventDates();
        }

        public async Task<EventServiceModel> GetAsyncWithId(int id)
        {
            var result = await _repo.GetAsyncWithId(id);

            //Problem With Event.User To EventServiceModel.User property Mapping. User To UserServiceModel
            //var srmodel = result.Adapt<EventServiceModel>();
            
            
            var usermodel = new UserServiceModel();
            usermodel.Email = result.User.Email;
            usermodel.FirstName = result.User.FirstName;
            usermodel.LastName = result.User.LastName;
            usermodel.Id = result.User.Id;
            usermodel.Password = null;
            usermodel.isAdmin = result.User.isAdmin;

            var srmodel = new EventServiceModel();
            srmodel.Id = result.Id;
            srmodel.Title = result.Title;
            srmodel.Description = result.Description;
            srmodel.isPublished = result.isPublished;
            srmodel.StartDate = result.StartDate;
            srmodel.User = usermodel;
            srmodel.UserId = result.UserId;
            srmodel.PhotoUrl = result.PhotoUrl;


            return srmodel;
        }

        public async Task UpdateAdmin(int id, bool isPublished, DateTime modifiedDate, int userId)
        {
            await _repo.UpdateAdmin(id, isPublished, modifiedDate, userId);
        }

        
    }
}
