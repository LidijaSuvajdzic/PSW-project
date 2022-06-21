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
        public DbSet<AppointmentFeedback> appointmentFeedback { get; set; }
        public DbSet<HospitalFeedback> hospitalFeedback { get; set; }
        public DbSet<Penal> penals { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }

        public DbSet<Referral> referrals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Firstname = "Lidija", Lastname = "Suvajdzic", Email = "suvajdziclidija@gmail.com", Passwordd = "1234567890", HealthCardNumber = 1234567890, Role = "ADMIN",IsBlocked=false,Penals=0,IsPotentiallyMalicious=false },
                new User { UserId = 2, Firstname = "Dragana", Lastname = "Arsin", Email = "draganaarsin97@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0987654321, Role = "DOCTOR", IsBlocked = false, Penals = 0, IsPotentiallyMalicious = false },
                new User { UserId = 3, Firstname = "Milica", Lastname = "Peric", Email = "milicaperic@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0111154321, Role = "DOCTOR", IsBlocked = false, Penals = 0, IsPotentiallyMalicious = false },
                new User { UserId = 4, Firstname = "Simonida", Lastname = "Simic", Email = "simonidasimic@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0982222321, Role = "DOCTOR", IsBlocked = false, Penals = 0, IsPotentiallyMalicious = false },
               new User { UserId = 5, Firstname = "Sanja", Lastname = "Peric", Email = "sanja@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0111154321, Role = "SPECIALIST", IsBlocked = false, Penals = 0, IsPotentiallyMalicious = false },
                new User { UserId =6, Firstname = "Stefan", Lastname = "Simic", Email = "stefan@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0982222321, Role = "SPECIALIST", IsBlocked = false, Penals = 0, IsPotentiallyMalicious = false },
                new User { UserId = 7, Firstname = "Kristina", Lastname = "Peric", Email = "kristina@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0111154321, Role = "PATIENT", IsBlocked = false, Penals = 0, IsPotentiallyMalicious = false },
                new User { UserId = 8, Firstname = "Esma", Lastname = "Simic", Email = "esma@gmail.com", Passwordd = "1234567890", HealthCardNumber = 0982222321, Role = "PATIENT", IsBlocked = false, Penals = 0, IsPotentiallyMalicious = false }
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
                    DateFrom = DateTime.ParseExact("2022-07-25 15:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-07-25 16:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 3,
                    IsFree = true
                },
                new FreeAppointment
                {
                    Id = 4,
                    DateFrom = DateTime.ParseExact("2022-07-26 15:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-07-26 16:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 4,
                    IsFree = true
                },
                new FreeAppointment
                {
                    Id = 5,
                    DateFrom = DateTime.ParseExact("2022-03-30 13:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-03-30 14:00:00", "yyyy-MM-dd HH:mm:ss",
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
                },
                new FreeAppointment
                {
                    Id = 7,
                    DateFrom = DateTime.ParseExact("2022-06-29 15:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-06-29 16:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 5,
                    IsFree = true
                },
                new FreeAppointment
                {
                    Id = 8,
                    DateFrom = DateTime.ParseExact("2022-03-22 13:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-03-22 14:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 6,
                    IsFree = true
                },
                new FreeAppointment
                {
                    Id = 9,
                    DateFrom = DateTime.ParseExact("2022-09-20 13:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DateTo = DateTime.ParseExact("2022-09-20 14:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    DoctorId = 5,
                    IsFree = true
                }
            );
        }
    }
}


