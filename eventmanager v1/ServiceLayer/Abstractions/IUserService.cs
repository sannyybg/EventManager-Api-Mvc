using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Abstractions
{
    public interface IUserService
    {

        Task<UserServiceModel> GetAsync(string username, string password);
        Task AddAsync(UserServiceModel user);

        Task<List<UserServiceModel>> GetAllAsync();

        Task DeleteAsync(int id);

    }
}
