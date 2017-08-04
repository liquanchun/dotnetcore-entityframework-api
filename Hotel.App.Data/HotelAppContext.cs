using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.App.Model;
using Hotel.App.Model.SYS;
using Microsoft.EntityFrameworkCore.Metadata;
using Hotel.App.Data.Repositories.SYS;

namespace Hotel.App.Data
{
    public class HotelAppContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<sys_function> SysFunctions { get; set; }
        public DbSet<sys_menu> SysMenus { get; set; }
        public DbSet<sys_org> SysOrgs { get; set; }
        public DbSet<sys_role> SysRoles { get; set; }
        public DbSet<sys_role_function> SysRoleFunctions { get; set; }

        public DbSet<sys_role_menu> SysRoleMenus { get; set; }
        public DbSet<sys_role_user> SysRoleUsers { get; set; }
        public DbSet<sys_user> SysUsers { get; set; }
        public DbSet<user_access_log> UserAccessLogs { get; set; }
        public DbSet<user_login_log> UserLoginLogs { get; set; }

        public HotelAppContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            _0SYSBuilder.Add(ref modelBuilder);

            #region 测试数据
            modelBuilder.Entity<Schedule>()
                .ToTable("Schedule");

            modelBuilder.Entity<Schedule>()
                .Property(s => s.CreatorId)
                .IsRequired();

            modelBuilder.Entity<Schedule>()
                .Property(s => s.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Schedule>()
                .Property(s => s.DateUpdated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Schedule>()
                .Property(s => s.Type)
                .HasDefaultValue(ScheduleType.Work);

            modelBuilder.Entity<Schedule>()
                .Property(s => s.Status)
                .HasDefaultValue(ScheduleStatus.Valid);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Creator)
                .WithMany(c => c.SchedulesCreated);

            modelBuilder.Entity<User>()
              .ToTable("User");

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Attendee>()
              .ToTable("Attendee");

            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.User)
                .WithMany(u => u.SchedulesAttended)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.Schedule)
                .WithMany(s => s.Attendees)
                .HasForeignKey(a => a.ScheduleId);
            #endregion
        }
    }
}
