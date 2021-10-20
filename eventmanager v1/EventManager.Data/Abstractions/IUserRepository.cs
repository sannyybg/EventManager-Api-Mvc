using EventManager.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Data.Abstractions
{
    public interface IUserRepository
    {

        Task CreateAsync(User ev);

        Task DeleteAsync(int id);

        Task<User> GetAsync(int id);

        Task<User> GetAsync(string username, string password);

        Task<List<User>> GetAllAsync();
    }
}
