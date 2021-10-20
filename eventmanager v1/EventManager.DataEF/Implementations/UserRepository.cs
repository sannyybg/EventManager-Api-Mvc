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
    class UserRepository : IUserRepository
    {

        readonly IBaseRepository<User> _baseRepo;


        public UserRepository(IBaseRepository<User> repo)
        {
            _baseRepo = repo;
        }

        public async Task<List<User>> GetAllAsync()
        {  
            return await _baseRepo.GetAllAsync();
        }

        
        public async Task CreateAsync(User user)
        {
            await _baseRepo.AddAsync(user);
        }

        public async Task<User> GetAsync(string username, string password)
        { 
            var user =  await _baseRepo.Table.FirstOrDefaultAsync(x => x.Email == username && x.Password == password);
            return user;
        }

        public async Task<User> GetAsync(int id)
        {
            return await _baseRepo.GetAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _baseRepo.DeleteAsync(id);
        }
    }
}
