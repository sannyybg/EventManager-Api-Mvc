using EventManager.Data.Abstractions;
using EventManager.DataEF.BaseRepository;
using EventManager.DataEF.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.DataEF.RepoExtensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepos(this IServiceCollection services)
        {
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
