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
    public class AppointmentService
    {

        private AppointmentRepository _appointmentRepository;
        private UserRepository _userRepository;

        public AppointmentService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<MyWebApiContext>();
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            builder.UseNpgsql(connectionString);
            _appointmentRepository = new AppointmentRepository(new MyWebApiContext(builder.Options));
            _userRepository = new UserRepository(new MyWebApiContext(builder.Options));
        }

        public AppointmentService(AppointmentRepository appointmentRepository, UserRepository userRepository) {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
        }
        public string checkAvailability(CheckingAppointmentDTO checkingAppointmentDTO)
        {
            String nameOfDoctor = checkingAppointmentDTO.SelectedDoctor.Split(" ")[0];
            User user = _userRepository.FindUserByFirstname(nameOfDoctor);
            String message = "";


            String datefrom = checkingAppointmentDTO.DateFrom + " " + checkingAppointmentDTO.TimeFrom + ":00";
            String dateto = checkingAppointmentDTO.DateTo + " " + checkingAppointmentDTO.TimeTo + ":00";

            DateTime dateFrom = DateTime.ParseExact(datefrom, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateTo = DateTime.ParseExact(dateto, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);


           List<FreeAppointment> freeAppointments = _appointmentRepository.findAppoinments(dateFrom,dateTo,user.UserId);
            if (freeAppointments.Count==0)
            {
                message = "No appointments found";
            }
            else {
                message = "We found an appointment for you";
            }
            Debug.WriteLine(message);
            return message;
        }


        public string findMessageForFindingAppointmentsByDoctor(RequestSuggestionDTO requestSuggestionDTO)
        {
            String nameOfDoctor = requestSuggestionDTO.SelectedDoctor.Split(" ")[0];
            User user = _userRepository.FindUserByFirstname(nameOfDoctor);

            List<FreeAppointment> freeAppointments = _appointmentRepository.findAppoinmentsByDoctor(user.UserId);
            String message = "";
            if (freeAppointments.Count == 0)
            {
                message = "No appointments found";
            }
            else
            {
                message = "We found an appointment for you";
            }
            return message;
        }

        public List<FreeAppointmentDTO> findAppointmentByDoctor(RequestSuggestionDTO requestSuggestionDTO)
        {
            String nameOfDoctor = requestSuggestionDTO.SelectedDoctor.Split(" ")[0];
            User user = _userRepository.FindUserByFirstname(nameOfDoctor);

            List<FreeAppointment> freeAppointments = _appointmentRepository.findAppoinmentsByDoctor(user.UserId);
            List<FreeAppointmentDTO> freeAppointmentDTOs = new List<FreeAppointmentDTO>();

            foreach (FreeAppointment fa in freeAppointments)
            {
                FreeAppointmentDTO fDTO = FreeAppointmentAdapter.FreeAppointmentToFreeAppointmentDTO(fa);
                fDTO.Doctor = user.Firstname + user.Lastname;
                freeAppointmentDTOs.Add(fDTO);
            }

            return freeAppointmentDTOs;
        }


        public string findMessageForFindingAppointmentsByTime(RequestSuggestionDTO requestSuggestionDTO)
        {

            String datefrom = requestSuggestionDTO.DateFrom + " " + requestSuggestionDTO.TimeFrom + ":00";
            String dateto = requestSuggestionDTO.DateTo + " " + requestSuggestionDTO.TimeTo + ":00";

            DateTime dateFrom = DateTime.ParseExact(datefrom, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateTo = DateTime.ParseExact(dateto, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);

            DateTime dateFromMinus = dateFrom.AddDays(-10);
            DateTime dateToPlus = dateTo.AddDays(10);

            List<FreeAppointment> freeAppointments = _appointmentRepository.findAppoinmentsByDate(dateFromMinus,dateToPlus);
            String message = "";
            if (freeAppointments.Count == 0)
            {
                message = "No appointments found";
            }
            else
            {
                message = "We found an appointment for you";
            }
            return message;
        }

        public List<FreeAppointmentDTO> findAppointmentByDate(RequestSuggestionDTO requestSuggestionDTO)
        {
            String nameOfDoctor = requestSuggestionDTO.SelectedDoctor.Split(" ")[0];
            User user = _userRepository.FindUserByFirstname(nameOfDoctor);

            String datefrom = requestSuggestionDTO.DateFrom + " " + requestSuggestionDTO.TimeFrom + ":00";
            String dateto = requestSuggestionDTO.DateTo + " " + requestSuggestionDTO.TimeTo + ":00";
            DateTime dateFrom = DateTime.ParseExact(datefrom, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateTo = DateTime.ParseExact(dateto, "yyyy-MM-dd HH:mm:ss",
                                      System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateFromMinus = dateFrom.AddDays(-10);
            DateTime dateToPlus = dateTo.AddDays(10);
            List<FreeAppointment> freeAppointments = _appointmentRepository.findAppoinmentsByDate(dateFromMinus, dateToPlus);

            List<FreeAppointmentDTO> freeAppointmentDTOs = new List<FreeAppointmentDTO>();

            foreach (FreeAppointment fa in freeAppointments)
            {
                FreeAppointmentDTO fDTO = FreeAppointmentAdapter.FreeAppointmentToFreeAppointmentDTO(fa);
                fDTO.Doctor = user.Firstname + user.Lastname;
                freeAppointmentDTOs.Add(fDTO);
            }
            return freeAppointmentDTOs;
        }
    }
}


