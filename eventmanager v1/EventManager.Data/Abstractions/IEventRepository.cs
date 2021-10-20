using EventManager.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Data.Abstractions
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllAsync();

        Task<List<Event>> GetEvents();

        Task Update(Event ev);

        Task CreateAsync(Event ev);

        Task<List<Event>> GetAsync(int id);

        Task<Event> GetAsyncWithId(int id);

        Task CheckEventDates();
        Task UpdateAdmin(int id, bool isPublished, DateTime modifiedDate, int userId);
        Task<List<Event>> GetFinishedEvents();
    }
}
