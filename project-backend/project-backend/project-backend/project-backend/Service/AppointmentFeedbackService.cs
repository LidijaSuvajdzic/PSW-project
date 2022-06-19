using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using project_backend.Adapter;
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
    public class AppointmentFeedbackService
    {

        private AppointmentFeedbackRepository _appointmentFeedbackRepository;
        private UserRepository _userRepository;
        private AppointmentRepository _appointmentRepository;

        public AppointmentFeedbackService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<MyWebApiContext>();
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            builder.UseNpgsql(connectionString);
            _appointmentFeedbackRepository = new AppointmentFeedbackRepository(new MyWebApiContext(builder.Options));
            _userRepository = new UserRepository(new MyWebApiContext(builder.Options));
            _appointmentRepository = new AppointmentRepository(new MyWebApiContext(builder.Options));
        }
        public AppointmentFeedbackService(AppointmentFeedbackRepository appointmentFeedbackRepository, UserRepository userRepository, AppointmentRepository appointmentRepository)
        {
            _appointmentFeedbackRepository = appointmentFeedbackRepository;
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
        }
        public void addAppointmentFeedback(AppointmentFeedbackDTO appointmentFeedbackDTO)
        {
            AppointmentFeedback appointmentFeedback = AppointmentFeedbackAdapter.AppointmentFeedbackDTOToAppointmentFeedback(appointmentFeedbackDTO);
            User patient = _userRepository.FindUserByFirstname(appointmentFeedbackDTO.PatientName);
            appointmentFeedback.PatientId = patient.UserId;
            appointmentFeedback.Id = GenerateId();
            appointmentFeedback.AppointmentId = appointmentFeedbackDTO.AppointmentId;
            Debug.WriteLine("id jee" + appointmentFeedback.AppointmentId);

            ReservedAppointment ra = _appointmentRepository.findAppointmentById(appointmentFeedback.AppointmentId);

            ra.IsRated = true;
            _appointmentRepository.UpdateReservedAppointment(ra);
            _appointmentFeedbackRepository.AddAppointmentFeedback(appointmentFeedback);
        }

        public int GenerateId()
        {
            int number = _appointmentFeedbackRepository.GetAllAppointmentFeedbacks().Count + 1;
            return number;
        }

   
    }
}
