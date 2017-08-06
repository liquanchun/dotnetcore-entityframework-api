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

            services.AddScoped<ISysOrgRepository, SysOrgRepository>();
            services.AddScoped<ISysFunctionRepository, SysFunctionRepository>();
            services.AddScoped<ISysMenuRepository, SysMenuRepository>();
            services.AddScoped<ISysRoleFunctionRepository, SysRoleFunctionRepository>();
            services.AddScoped<ISysRoleMenuRepository, SysRoleMenuRepository>();

            services.AddScoped<ISysRoleRepository, SysRoleRepository>();
            services.AddScoped<ISysRoleUserRepository, SysRoleUserRepository>();
            services.AddScoped<IUserAccessLogRepository, UserAccessLogRepository>();
            services.AddScoped<IUserLoginLogRepository, UserLoginLogRepository>();
            services.AddScoped<ISysUserRepository, SysUserRepository>();

            services.AddScoped<ISysDicRepository, SysDicRepository>();
        }
    }
}
