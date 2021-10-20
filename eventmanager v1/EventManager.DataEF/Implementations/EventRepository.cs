using EventManager.Data.Abstractions;
using EventManager.DataEF.BaseRepository;
using EventManager.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DataEF.Implementations
{
    public class EventRepository : IEventRepository
    {
        readonly IBaseRepository<Event> _baseRepo;


        public EventRepository(IBaseRepository<Event> repo)
        {
            
            _baseRepo = repo;
            
        }

        public async Task<List<Event>> GetAllAsync()
        {
            
            return await _baseRepo.Table.Where(x => x.isPublished && !x.isAchieved).ToListAsync();
                        
        }

        public async Task<List<Event>> GetEvents()
        {
            return await _baseRepo.GetAllAsync();
        }

        public async Task<List<Event>> GetFinishedEvents()
        {
            return await _baseRepo.Table.Where(x => x.isAchieved && x.isPublished).ToListAsync();
        }


        public async Task<List<Event>> GetAsync(int id)
        {
            var evt = await _baseRepo.Table.Where(x => x.UserId == id && x.ModifiedDate >= DateTime.Now).ToListAsync();
            return evt;
        }


        public async Task CheckEventDates()
        {
            var xx = await _baseRepo.GetAllAsync();
            foreach (var item in xx)
            {
                if (item.StartDate < DateTime.Now)
                {
                    item.isAchieved = true;
                    await Update(item);
                }
            }

        }



        public async Task<Event> GetAsyncWithId(int id)
        {

            var evt = await _baseRepo.Table.Where(x => x.Id == id).Include(x => x.User).FirstOrDefaultAsync();

            return evt;
        }




        public async Task CreateAsync(Event ev)
        {
            ev.ModifiedDate = DateTime.Now.AddDays(2);
            await _baseRepo.AddAsync(ev);
            return;
        }






        public async Task Update(Event ev)
        {
            //await _baseRepo.UpdateAsync(ev);
            
            var xx = await _baseRepo.GetAsync(ev.Id);

            if (xx.ModifiedDate >= DateTime.Now)
            {
                xx.Title = ev.Title;
                xx.StartDate = ev.StartDate;
                xx.Description = ev.Description;
                xx.PhotoUrl = ev.PhotoUrl;
                await _baseRepo.UpdateAsync(xx);
            }
            else
            {
                return;
            }

        }

        


        public async Task UpdateAdmin(int id, bool isPublished, DateTime modifiedDate, int userId)
        {
            var xx = await _baseRepo.GetAsync(id);
            xx.isPublished = isPublished;
            xx.ModifiedDate = modifiedDate;
            xx.UserId = userId;
            await _baseRepo.UpdateAsync(xx);
        }

        
    }
}
