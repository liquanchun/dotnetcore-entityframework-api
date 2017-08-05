using Hotel.App.Model.SYS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.App.Data.Repositories.SYS
{
    public static class _0SYSBuilder
    {
        public static void Add(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sys_function>()
               .ToTable("sys_function");

            modelBuilder.Entity<sys_menu>()
                .ToTable("sys_menu");

            modelBuilder.Entity<sys_org>()
                .ToTable("sys_org");

            modelBuilder.Entity<sys_role>()
                .ToTable("sys_role");

            modelBuilder.Entity<sys_role_function>()
                .ToTable("sys_role_function");

            modelBuilder.Entity<sys_role_menu>()
                .ToTable("sys_role_menu");

            modelBuilder.Entity<sys_role_user>()
                .ToTable("sys_role_user");

            modelBuilder.Entity<sys_user>()
                .ToTable("sys_user");

            modelBuilder.Entity<user_access_log>()
                .ToTable("user_access_log");

            modelBuilder.Entity<user_login_log>()
                .ToTable("user_login_log");
        }
    }
}
