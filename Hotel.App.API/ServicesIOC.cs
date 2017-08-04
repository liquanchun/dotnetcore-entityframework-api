using Hotel.App.Data.Abstract;
using Hotel.App.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.App.API
{
    public static class ServicesIOC
    {
        public static void Add(ref IServiceCollection services)
        {
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAttendeeRepository, AttendeeRepository>();
        }
    }
}
