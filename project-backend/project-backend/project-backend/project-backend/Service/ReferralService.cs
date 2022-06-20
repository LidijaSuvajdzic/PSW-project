using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using project_backend.DTO;
using project_backend.Models;
using project_backend.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine("Doctor je"+referralDTO.DoctorName);
            Debug.WriteLine("SPecijaliste je"+referralDTO.SelectedSpecialist);
            Debug.WriteLine("Pacijent je"+ referralDTO.SelecterPatient);
            User patient= _userRepository.FindUserByFirstname(referralDTO.SelecterPatient.Split(" ")[0]);
            User specialist= _userRepository.FindUserByFirstname(referralDTO.SelectedSpecialist.Split(" ")[0]);
            User doctor = _userRepository.FindUserByFirstname(referralDTO.DoctorName);
            referral.PatientId = patient.UserId;
            referral.SpecialistId = specialist.UserId;
            referral.DoctorId = doctor.UserId;
            referral.Reason = referralDTO.Reason;


            FreeAppointment freeAppointment = _appointmentRepository.find(referralDTO.Id);
            freeAppointment.IsFree = false;


            ReservedAppointment reservedAppointment = new ReservedAppointment();
            reservedAppointment.Id = _appointmentRepository.GetAllReservedAppointments().Count + 5;
            reservedAppointment.DateFrom = freeAppointment.DateFrom;
            reservedAppointment.DateTo = freeAppointment.DateTo;
            reservedAppointment.DoctorId = specialist.UserId;
            reservedAppointment.PatientId = patient.UserId;
            reservedAppointment.IsRated = false;

            referral.DateFrom = reservedAppointment.DateFrom;
            referral.DateTo = reservedAppointment.DateTo;
            SaveToFile(referral);
            _referralRepository.addReferral(referral);

            _appointmentRepository.UpdateFreeAppointment(freeAppointment);         
            _appointmentRepository.AddAppointment(reservedAppointment);
        }


        public void SaveToFile(Referral referral) {
            User patient = _userRepository.FindUserById(referral.PatientId);
            User specialist = _userRepository.FindUserById(referral.SpecialistId);
            User doctor = _userRepository.FindUserById(referral.DoctorId);
            string fileName = @"C:\Users\Lidija\Desktop\PSW-project\project-backend\project-backend\project-backend\project-backend\Referrals\For"+patient.Firstname+patient.Lastname+referral.Id+ ".txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("Referral letter:");
                    sw.WriteLine("Patient:" + patient.Firstname + " " + patient.Lastname); ;
                    sw.WriteLine("Specialist:" + specialist.Firstname + " " + specialist.Lastname);
                    sw.WriteLine("Doctor who prescribed the referral letter:" + doctor.Firstname + " " + doctor.Lastname);
                    sw.WriteLine("Reason:" + referral.Reason);
                    sw.WriteLine("Date and time:" + "DATE FROM"+referral.DateFrom + "-DATE TO"+ referral.DateTo ) ;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }


        }
        public int GenerateId()
        {
            int number = _referralRepository.GetAllReferrals().Count + 5;
            return number;
        }
    }
}
