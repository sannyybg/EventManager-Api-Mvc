using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Abstractions
{
    public interface IEventService
    {
        Task<List<EventServiceModel>> GetAll();

        Task<List<EventServiceModel>> GetEvents();

        Task<EventServiceModel> GetAsyncWithId(int id);

        Task Update(EventServiceModel evt);

        Task<List<EventServiceModel>> GetAsync(int id);
        Task AddAsync(EventServiceModel evt);

        Task CheckEventDates();
        Task UpdateAdmin(int id, bool isPublished, DateTime modifiedDate, int userId);
        Task<List<EventServiceModel>> GetFinishedEvents();
    }
}
