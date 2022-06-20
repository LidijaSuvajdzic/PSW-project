using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using project_backend.DTO;
using project_backend.Models;
using project_backend.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Service
{
    public class ReferralService
    {
        private ReferralRepository _referralRepository;
        private UserRepository _userRepository;
        private AppointmentRepository _appointmentRepository;

        public ReferralService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<MyWebApiContext>();
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            builder.UseNpgsql(connectionString);
            _referralRepository = new ReferralRepository(new MyWebApiContext(builder.Options));
            _userRepository = new UserRepository(new MyWebApiContext(builder.Options));
            _appointmentRepository = new AppointmentRepository(new MyWebApiContext(builder.Options));
        }

        public ReferralService(ReferralRepository referralRepository, UserRepository userRepository,AppointmentRepository appointmentRepository)
        {
            _referralRepository = referralRepository;
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
        }
        internal void addReferral(ReferralDTO referralDTO)
        {
            //kreirati fajl!!!!!!!!!!!!!
            Referral referral = new Referral();
            referral.Id = GenerateId();

            User patient= _userRepository.FindUserByFirstname(referralDTO.SelecterPatient.Split(" ")[0]);
            User specialist= _userRepository.FindUserByFirstname(referralDTO.SelectedSpecialist.Split(" ")[0]);
            User doctor = _userRepository.FindUserByFirstname(referralDTO.DoctorName);
            referral.PatientId = patient.UserId;
            referral.SpecialistId = specialist.UserId;
            referral.DoctorId = doctor.UserId;
            referral.Reason = referralDTO.Reason;

            _referralRepository.addReferral(referral);
            SaveToFile(referral);
            FreeAppointment freeAppointment = _appointmentRepository.find(referralDTO.Id);
            freeAppointment.IsFree = false;
            _appointmentRepository.UpdateFreeAppointment(freeAppointment);

            ReservedAppointment reservedAppointment = new ReservedAppointment();
            reservedAppointment.Id = _appointmentRepository.GetAllReservedAppointments().Count + 5;
            reservedAppointment.DateFrom = freeAppointment.DateFrom;
            reservedAppointment.DateTo = freeAppointment.DateTo;
            reservedAppointment.DoctorId = doctor.UserId;
            reservedAppointment.PatientId = patient.UserId;
            reservedAppointment.IsRated = false;
            _appointmentRepository.AddAppointment(reservedAppointment);
        }


        public void SaveToFile(Referral referral) { 
        
        
        
        }
        public int GenerateId()
        {
            int number = _referralRepository.GetAllReferrals().Count + 5;
            return number;
        }
    }
}
