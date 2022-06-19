using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using project_backend.Adapter;
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
    public class HospitalFeedbackService
    {
        private HospitalFeedbackRepository _hospitalFeedbackRepository;
        private UserRepository _userRepository;

        public HospitalFeedbackService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<MyWebApiContext>();
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            builder.UseNpgsql(connectionString);
            _hospitalFeedbackRepository = new HospitalFeedbackRepository(new MyWebApiContext(builder.Options));
            _userRepository = new UserRepository(new MyWebApiContext(builder.Options));
        }
        public HospitalFeedbackService(HospitalFeedbackRepository hospitalFeedbackRepository, UserRepository userRepository)
        {
            _hospitalFeedbackRepository = hospitalFeedbackRepository;
            _userRepository = userRepository;
        }

        public void addAppointmentFeedback(HospitalFeedbackDTO hospitalFeedbackDTO)
        {
            HospitalFeedback hospitalFeedback = HospitalFeedbackAdapter.HospitalFeedbackDTOToHospitalFeedback(hospitalFeedbackDTO);
            User patient = _userRepository.FindUserByFirstname(hospitalFeedbackDTO.PatientName);
            hospitalFeedback.PatientId = patient.UserId;
            hospitalFeedback.Id = GenerateId();
      

            _hospitalFeedbackRepository.AddHospitalFeedback(hospitalFeedback);
        }


        public int GenerateId()
        {
            int number = _hospitalFeedbackRepository.GetAllHospitalFeedbacks().Count + 1;
            return number;
        }
    }
}
