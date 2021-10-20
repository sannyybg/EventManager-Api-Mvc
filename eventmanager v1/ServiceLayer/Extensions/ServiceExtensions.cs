using EventManager.Data.Abstractions;
using EventManager.DataEF.BaseRepository;
using EventManager.DataEF.Implementations;
using EventManager.DataEF.RepoExtensions;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Abstractions;
using ServiceLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Extensions
{
    public static class ServiceExtensions
    {
        
            public static void AddServices(this IServiceCollection services)
            {

                services.AddTransient<IEventService, EventService>();
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<IJWTService, JWTService>();


            services.AddRepos();

            

            }
        
    }
}
