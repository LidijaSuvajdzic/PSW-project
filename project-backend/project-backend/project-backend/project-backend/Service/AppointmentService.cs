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
        private ReferralRepository _referralRepository;
        private PenalRepository _penalRepository;
        public AppointmentService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<MyWebApiContext>();
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            builder.UseNpgsql(connectionString);
            _appointmentRepository = new AppointmentRepository(new MyWebApiContext(builder.Options));
            _userRepository = new UserRepository(new MyWebApiContext(builder.Options));
            _referralRepository = new ReferralRepository(new MyWebApiContext(builder.Options));
            _penalRepository = new PenalRepository(new MyWebApiContext(builder.Options));
        }

        public AppointmentService(AppointmentRepository appointmentRepository, UserRepository userRepository, ReferralRepository referralRepository, PenalRepository penalRepository) {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
            _referralRepository = referralRepository;
            _penalRepository = penalRepository;
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



        public void addAppointment(ReservedAppointmentDTO reservedAppointmentDTO)
        {
            String datefrom = reservedAppointmentDTO.DateFrom + " " + reservedAppointmentDTO.TimeFrom + ":00";
            String dateto = reservedAppointmentDTO.DateTo + " " + reservedAppointmentDTO.TimeTo + ":00";

            DateTime dateFrom = DateTime.ParseExact(datefrom, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateTo = DateTime.ParseExact(dateto, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);

            String nameOfDoctor = reservedAppointmentDTO.Doctor.Split(" ")[0];
            User doctor = _userRepository.FindUserByFirstname(nameOfDoctor);
            User patient = _userRepository.FindUserByFirstname(reservedAppointmentDTO.Patient);
            ReservedAppointment reservedAppointment = ReservedAppointmentAdapter.ReservedAppointmentDTOToReservedAppointment(reservedAppointmentDTO);
            reservedAppointment.DoctorId = doctor.UserId;
            reservedAppointment.PatientId = patient.UserId;
            reservedAppointment.Id = GenerateId();
            reservedAppointment.IsRated = false;
            FreeAppointment fa =  _appointmentRepository.findAppoinment(dateFrom, dateTo, doctor.UserId);
            fa.IsFree = false;
            _appointmentRepository.UpdateFreeAppointment(fa);
            _appointmentRepository.AddAppointment(reservedAppointment);
        }

        public string checkDates(int id)
        {
            String message = "";
            ReservedAppointment reservedAppointment = _appointmentRepository.findAppointmentById(id);
            double days = (reservedAppointment.DateFrom - DateTime.Now).TotalDays;
            Debug.WriteLine("razlika u satima je"+ days);
            if (days < 2)
            {
                message = "You can't cancel the appointment!";
            }
            return message;
        }

        public void cancelAppointment(int id,String firstname,String lastname)
        { 
            User patient = _userRepository.FindUserByFirstnameAndLastname(firstname,lastname);

            ReservedAppointment reservedAppointment = _appointmentRepository.findAppointmentById(id);
            FreeAppointment freeAppointment = _appointmentRepository.findAppoinmentByDateAndId(reservedAppointment.DateFrom,reservedAppointment.DateTo,reservedAppointment.DoctorId);
            int doctorId = reservedAppointment.DoctorId;
            User doctor = _userRepository.FindUserById(doctorId);
            if (doctor.Role=="SPECIALIST") {
                Referral referral = _referralRepository.findReferral(reservedAppointment.DateFrom,reservedAppointment.DateTo,reservedAppointment.DoctorId,reservedAppointment.PatientId);
                _referralRepository.RemoveReferral(referral);
            }
            freeAppointment.IsFree = true;

            PenalService penalService = new PenalService();
            Penal penal = new Penal();
            penal.PenalId = penalService.GenerateId();
            penal.PatientId = patient.UserId;
            penal.Date = DateTime.Now;
            _penalRepository.addPenal(penal);

            Debug.WriteLine("Kreirala sam penal");

            patient.Penals += 1;
            _userRepository.UpdateUser(patient);
            Debug.WriteLine("Azurirala pacijenta");
            //cekiraj
            penalService.checkMalicious(patient);
            Debug.WriteLine("Ni ovde nije puklo");
            _appointmentRepository.UpdateFreeAppointment(freeAppointment);
            _appointmentRepository.deleteReservedAppointment(reservedAppointment);

        }

        public void addAppointmentFromTable(int id,String patient)
        {


            FreeAppointment fa = _appointmentRepository.find(id);

            ReservedAppointment ra = new ReservedAppointment();
            ra.Id = GenerateId();
            ra.DateFrom = fa.DateFrom;
            ra.DateTo = fa.DateTo;
            ra.DoctorId = fa.DoctorId;
            User p = _userRepository.FindUserByFirstname(patient);
            ra.PatientId = p.UserId;
            ra.IsRated = false;
            _appointmentRepository.AddAppointment(ra);
            fa.IsFree = false;
            _appointmentRepository.UpdateFreeAppointment(fa);
        }

        public int GenerateId()
        {
            int number = _appointmentRepository.GetAllReservedAppointments().Count + 10;
            return number;
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
                fDTO.Doctor = user.Firstname + " "+user.Lastname;
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
                fDTO.Doctor = user.Firstname + " " +user.Lastname;
                freeAppointmentDTOs.Add(fDTO);
            }
            return freeAppointmentDTOs;
        }

        public List<ReservedAppointmentDTO> findMyFutureAppointments(String firstname)
        {
            User u = _userRepository.FindUserByFirstname(firstname);
            List<ReservedAppointment> lists = _appointmentRepository.findMyFutureAppointments(DateTime.Now, u.UserId);
            List<ReservedAppointmentDTO> listsDTO = new List<ReservedAppointmentDTO>();
            foreach (ReservedAppointment ra in lists) {
                ReservedAppointmentDTO raDTO = ReservedAppointmentAdapter.ReservedAppointmentToReservedAppointmentDTO(ra);
                User doctor = _userRepository.FindUserById(ra.DoctorId);
                raDTO.Doctor = doctor.Firstname + " " + doctor.Lastname;
                listsDTO.Add(raDTO);
            }

        return listsDTO;
        }

        public List<ReservedAppointmentDTO> findMyPreviousAppointments(String firstname)
        {
            User u = _userRepository.FindUserByFirstname(firstname);
            List<ReservedAppointment> lists = _appointmentRepository.findMyPreviousAppointments(DateTime.Now,u.UserId);
            List<ReservedAppointmentDTO> listsDTO = new List<ReservedAppointmentDTO>();
            foreach (ReservedAppointment ra in lists)
            {
                ReservedAppointmentDTO raDTO = ReservedAppointmentAdapter.ReservedAppointmentToReservedAppointmentDTO(ra);
                User doctor = _userRepository.FindUserById(ra.DoctorId);
                raDTO.Doctor = doctor.Firstname + " " + doctor.Lastname;
                listsDTO.Add(raDTO);
            }
            return listsDTO;
        }

        public List<FreeAppointmentDTO> findAppointmentBySpecialist(String selestedDoctor) {
            User specialist = _userRepository.FindUserByFirstname(selestedDoctor.Split(" ")[0]);
            List<FreeAppointment> list = _appointmentRepository.findAppoinmentsByDoctor(specialist.UserId);
            List<FreeAppointmentDTO> listDTO = new List<FreeAppointmentDTO>();

            foreach (FreeAppointment fa in list)
            {
                FreeAppointmentDTO fDTO = FreeAppointmentAdapter.FreeAppointmentToFreeAppointmentDTO(fa);
                listDTO.Add(fDTO);
            }

            return listDTO;
        }

    }




}


