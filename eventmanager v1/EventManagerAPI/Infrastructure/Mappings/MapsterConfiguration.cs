using EventManager.Domain.POCO;
using EventManagerAPI.Models;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagerAPI.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void AddMappings(this IServiceCollection services)
        {
            TypeAdapterConfig<UserServiceModel, User>
            .NewConfig()
            .TwoWays();


            TypeAdapterConfig<UserRequest, UserServiceModel>
            .NewConfig();
            

            TypeAdapterConfig<UserServiceModel, UserDTO>
            .NewConfig();

            TypeAdapterConfig<EventServiceModel, Event>
            .NewConfig()
            .TwoWays();

            TypeAdapterConfig<EventRequest, EventServiceModel>
            .NewConfig();



            TypeAdapterConfig<EventServiceModel, EventDTO>
            .NewConfig();

            TypeAdapterConfig<EventPutRequest, EventServiceModel>
            .NewConfig();

            



        }
    }
}
