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
    class UserService : IUserService
    {

        private IUserRepository _repo;
        private readonly IJWTService _jwtService;

        public UserService(IUserRepository repo, IJWTService jwtService)
        {
            _repo = repo;
            _jwtService = jwtService;
        }
        public async Task AddAsync(UserServiceModel user)
        {
            var newuser = user.Adapt<User>();
            await _repo.CreateAsync(newuser);
        }

        public async Task<UserServiceModel> GetAsync(string username, string password)
        {
            var user = await _repo.GetAsync(username, password);
            var result = user.Adapt<UserServiceModel>();
            string token = null;

            if (result.isAdmin)
            {
                token = _jwtService.GenerateSecurityToken(result.isAdmin, result.Id);
            }
            else
            {
                token = _jwtService.GenerateSecurityToken(false, result.Id);
            }

            result.Token = token;

            return result;
        }

        public async Task<List<UserServiceModel>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();
            return result.Adapt<List<UserServiceModel>>();
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
