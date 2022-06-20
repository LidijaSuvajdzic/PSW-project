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

        internal void setPublic(int id)
        {
            HospitalFeedback hospitalFeedback= _hospitalFeedbackRepository.FindById(id);
            hospitalFeedback.IsPosted = true;
            _hospitalFeedbackRepository.UpdateHospitalFeedback(hospitalFeedback);
        }

        public void addHospitalFeedbackFeedback(HospitalFeedbackDTO hospitalFeedbackDTO)
        {
            HospitalFeedback hospitalFeedback = HospitalFeedbackAdapter.HospitalFeedbackDTOToHospitalFeedback(hospitalFeedbackDTO);
            User patient = _userRepository.FindUserByFirstname(hospitalFeedbackDTO.PatientName);
            hospitalFeedback.PatientId = patient.UserId;
            hospitalFeedback.Id = GenerateId();
            hospitalFeedback.IsPosted = false;

            _hospitalFeedbackRepository.AddHospitalFeedback(hospitalFeedback);
        }

        internal void removePublic(int id)
        {
            HospitalFeedback hospitalFeedback = _hospitalFeedbackRepository.FindById(id);
            hospitalFeedback.IsPosted = false;
            _hospitalFeedbackRepository.UpdateHospitalFeedback(hospitalFeedback);
        }

        public List<HospitalFeedbackDTO> GetAllHospitalFeedback()
        {
            List<HospitalFeedback> hospitalFeedback =  _hospitalFeedbackRepository.GetAllHospitalFeedbacks();
            List<HospitalFeedbackDTO> dTOs = new List<HospitalFeedbackDTO>();
            foreach(HospitalFeedback h in hospitalFeedback)
            {
                HospitalFeedbackDTO dto = new HospitalFeedbackDTO();
                dto.Grade = h.Grade.ToString();
                dto.Comment = h.Comment;
                User patient = _userRepository.FindUserById(h.PatientId);
                dto.PatientName = patient.Firstname;
                dto.PatientLastname = patient.Lastname;
                dto.IsAnonymously = h.IsAnonymously;
                dto.Id = h.Id;
                dto.IsPosted = h.IsPosted;
                dTOs.Add(dto);
            }
            return dTOs;
        }

        public int GenerateId()
        {
            int number = _hospitalFeedbackRepository.GetAllHospitalFeedbacks().Count + 1;
            return number;
        }
    }
}
