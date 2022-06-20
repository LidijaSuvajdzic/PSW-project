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
        public DbSet<FreeAppointment> freeAppointments { get; set; }
        public DbSet<ReservedAppointment> reservedAppointments { get; set; }
        public DbSet<AppointmentFeedback> appointmentFeedbacks { get; set; }
        public DbSet<HospitalFeedback> hospitalFeedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Firstname = "Lidija", Lastname = "Suvajdzic", Email = "suvajdziclidija@gmail.com", Passwordd = "1234567890", HealthCardNumber = 1234567890, Role = "ADMIN" },
                new User { UserId = 2, Firstname = "Dragana", Lastname = "Arsin", Email = "draganaarsin97@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0987654321, Role = "DOCTOR" },
                new User { UserId = 3, Firstname = "Milica", Lastname = "Peric", Email = "milicaperic@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0111154321, Role = "DOCTOR" },
                new User { UserId = 4, Firstname = "Simonida", Lastname = "Simic", Email = "simonidasimic@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0982222321, Role = "DOCTOR" }

            );

            modelBuilder.Entity<FreeAppointment>().HasData(
                new FreeAppointment
                {
                    Id = 1,
                    DateFrom = DateTime.ParseExact("2022-06-20 13:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-06-20 14:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 2,
                    IsFree = true
                },

                new FreeAppointment
                {
                    Id = 2,
                    DateFrom = DateTime.ParseExact("2022-06-20 14:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-06-20 15:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 2,
                    IsFree = true
                },
                new FreeAppointment
                {
                    Id = 3,
                    DateFrom = DateTime.ParseExact("2022-06-20 15:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-06-20 16:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 3,
                    IsFree = true
                },
                new FreeAppointment
                {
                    Id = 4,
                    DateFrom = DateTime.ParseExact("2022-06-20 15:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-06-20 16:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 4,
                    IsFree = true
                },
                new FreeAppointment
                {
                    Id = 5,
                    DateFrom = DateTime.ParseExact("2022-03-20 13:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-03-20 14:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 2,
                    IsFree = true
                },
                new FreeAppointment
                {
                    Id = 6,
                    DateFrom = DateTime.ParseExact("2022-08-20 13:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-08-20 14:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 3,
                    IsFree = true
                }
            );
        }
    }
}


