using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Models
{
    public class MyWebApiContext : DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Firstname="Lidija", Lastname="Suvajdzic", Email="suvajdziclidija@gmail.com", Passwordd="1234567890",HealthCardNumber= 1234567890,Role="ADMIN" },
                new User { UserId = 2, Firstname = "Dragana", Lastname = "Arsin", Email = "draganaarsin97@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0987654321, Role = "DOCTOR" },
                new User { UserId = 3, Firstname = "Milica", Lastname = "Peric", Email = "milicaperic@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0111154321, Role = "DOCTOR" },
                new User { UserId = 4, Firstname = "Simonida", Lastname = "Simic", Email = "simonidasimic@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0982222321, Role = "DOCTOR" }

            );
        }
    }
}