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
    public class PrescriptionService
    {
        private PrescriptionRepository _prescriptionRepository;
        private UserRepository _userRepository;

        public PrescriptionService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<MyWebApiContext>();
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            builder.UseNpgsql(connectionString);
            _prescriptionRepository = new PrescriptionRepository(new MyWebApiContext(builder.Options));
            _userRepository = new UserRepository(new MyWebApiContext(builder.Options));
        }

        public PrescriptionService(PrescriptionRepository prescriptionRepository, UserRepository userRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _userRepository = userRepository;
        }
        internal void AddPrescription(PrescriptionDTO prescriptionDTO)
        {
            User patient = _userRepository.FindUserByFirstnameAndLastname(prescriptionDTO.Patient.Split(" ")[0], prescriptionDTO.Patient.Split(" ")[1]);
            User doctor = _userRepository.FindUserByFirstnameAndLastname(prescriptionDTO.Doctor.Split(" ")[0], prescriptionDTO.Doctor.Split(" ")[1]);

            Prescription prescription = new Prescription();
            prescription.Id = GenerateId();
            prescription.PatientId = patient.UserId;
            prescription.DoctorId = doctor.UserId;
            prescription.Date = DateTime.Now;
            prescription.Drug = prescriptionDTO.Drug;
            prescription.Usage = prescriptionDTO.Usage;

            _prescriptionRepository.addPrescription(prescription);
        }



        public int GenerateId() {

            int count= _prescriptionRepository.getAllPrescription().Count+10;

            return count;
        }
    }
}
