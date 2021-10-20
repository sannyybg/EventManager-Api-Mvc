using EventManager.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.PersistenceDB.Context
{
    public class EventManagerDbContext : DbContext
    {

        private readonly string _connectionString;
        public EventManagerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventManagerDbContext).Assembly);
            modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "test", LastName = "test", Email="test@gmail.com", Password="test1234" });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, FirstName = "james", LastName = "smith", Email = "james@gmail.com", Password = "test1234" });
            modelBuilder.Entity<User>().HasData(new User { Id = 3, FirstName = "leo", LastName = "messi", Email = "lmessi@gmail.com", Password = "test1234" });
            modelBuilder.Entity<Event>().HasData(new Event { Id=1, Title = "titletest", Description = "descr", StartDate=DateTime.Now.AddDays(2), UserId=1 });
            modelBuilder.Entity<Event>().HasData(new Event { Id = 6, Title = "EventTitle", Description = "descr", StartDate = DateTime.Now.AddDays(2), UserId = 2 });
            modelBuilder.Entity<Event>().HasData(new Event { Id = 7, Title = "FootballMatch", Description = "description", StartDate = DateTime.Now.AddDays(2), UserId = 3 });
            
        }





        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
