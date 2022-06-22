using project_backend.DTO;
using project_backend.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project_backendTests
{
    public class AppointmentTests
    {
        [Fact]
        public void findAppointmentBySpecialist()
        {
            AppointmentService appointmentService = new AppointmentService();
            String specialist = "Stefan Simic";
           List<FreeAppointmentDTO>  freeAppointmentDTOs = appointmentService.findAppointmentBySpecialist(specialist);
            Assert.NotNull(freeAppointmentDTOs);
        }

        [Fact]
        public void findMyPreviousAppointments()
        {
            AppointmentService appointmentService = new AppointmentService();
            String name = "Kristina";
            List<ReservedAppointmentDTO> freeAppointmentDTOs = appointmentService.findMyPreviousAppointments(name);
            Assert.NotNull(freeAppointmentDTOs);
        }

        [Fact]
        public void findMyFutureAppointments()
        {
            AppointmentService appointmentService = new AppointmentService();
            String name = "Kristina";
            List<ReservedAppointmentDTO> freeAppointmentDTOs = appointmentService.findMyFutureAppointments(name);
            Assert.NotNull(freeAppointmentDTOs);
        }

        [Fact]
        public void findAppointmentByDate()
        {
            AppointmentService appointmentService = new AppointmentService();

            RequestSuggestionDTO requestSuggestionDTO = new RequestSuggestionDTO();
            requestSuggestionDTO.Id = 1;
            requestSuggestionDTO.DateFrom = "2022-10-10";
            requestSuggestionDTO.DateTo = "2022-10-10";
            requestSuggestionDTO.TimeFrom = "13:20";
            requestSuggestionDTO.TimeTo = "14:20";
            requestSuggestionDTO.SelectedDoctor = "Simonida Simic";
            requestSuggestionDTO.Priority = "Doctor";
            List<FreeAppointmentDTO>  list =appointmentService.findAppointmentByDate(requestSuggestionDTO);
            Assert.NotNull(list);
        }

        [Fact]
        public void findMessageForFindingAppointmentsByTime()
        {
            AppointmentService appointmentService = new AppointmentService();
            RequestSuggestionDTO requestSuggestionDTO = new RequestSuggestionDTO();
            requestSuggestionDTO.Id = 1;
            requestSuggestionDTO.DateFrom = "2022-10-10";
            requestSuggestionDTO.DateTo = "2022-10-10";
            requestSuggestionDTO.TimeFrom = "13:20";
            requestSuggestionDTO.TimeTo = "14:20";
            requestSuggestionDTO.SelectedDoctor = "Simonida Simic";
            requestSuggestionDTO.Priority = "Doctor";
            String message = appointmentService.findMessageForFindingAppointmentsByTime(requestSuggestionDTO);
            Assert.NotNull(message);

        }

        public void findAppointmentByDoctor()
        {
            AppointmentService appointmentService = new AppointmentService();

            RequestSuggestionDTO requestSuggestionDTO = new RequestSuggestionDTO();
            requestSuggestionDTO.Id = 1;
            requestSuggestionDTO.DateFrom = "2022-10-10";
            requestSuggestionDTO.DateTo = "2022-10-10";
            requestSuggestionDTO.TimeFrom = "13:20";
            requestSuggestionDTO.TimeTo = "14:20";
            requestSuggestionDTO.SelectedDoctor = "Simonida Simic";
            requestSuggestionDTO.Priority = "Doctor";
            List<FreeAppointmentDTO> list = appointmentService.findAppointmentByDoctor(requestSuggestionDTO);
            Assert.NotNull(list);
        }

        [Fact]
        public void findMessageForFindingAppointmentsByDoctor()
        {
            AppointmentService appointmentService = new AppointmentService();
            RequestSuggestionDTO requestSuggestionDTO = new RequestSuggestionDTO();
            requestSuggestionDTO.Id = 1;
            requestSuggestionDTO.DateFrom = "2022-10-10";
            requestSuggestionDTO.DateTo = "2022-10-10";
            requestSuggestionDTO.TimeFrom = "13:20";
            requestSuggestionDTO.TimeTo = "14:20";
            requestSuggestionDTO.SelectedDoctor = "Simonida Simic";
            requestSuggestionDTO.Priority = "Doctor";
            String message = appointmentService.findMessageForFindingAppointmentsByDoctor(requestSuggestionDTO);
            Assert.NotNull(message);

        }

        [Fact]
        public void addAppointmentFromTable()
        {
            AppointmentService appointmentService = new AppointmentService();
            int id = 3;
            string name = "Kristina";
            appointmentService.addAppointmentFromTable(id,name);


        }

        [Fact]
        public void cancelAppointment()
        {
            AppointmentService appointmentService = new AppointmentService();
            int id = 5;
           String firstname = "Kristina";
            String lastname = "Peric";
            appointmentService.cancelAppointment(id,firstname,lastname);

        }

        [Fact]
        public void checkDates()
        {
            AppointmentService appointmentService = new AppointmentService();
            String message = appointmentService.checkDates(6);
            Assert.NotNull(message);


        }

        [Fact]
        public void checkAvailability()
        {
            AppointmentService appointmentService = new AppointmentService();
            CheckingAppointmentDTO checkingAppointmentDTO = new CheckingAppointmentDTO();
            checkingAppointmentDTO.DateFrom = "2022-10-10";
            checkingAppointmentDTO.DateTo = "2022-10-10";
            checkingAppointmentDTO.TimeFrom = "13:20";
            checkingAppointmentDTO.TimeTo = "14:20";
            checkingAppointmentDTO.SelectedDoctor = "Simonida Simic";
            String message = appointmentService.checkAvailability(checkingAppointmentDTO);
            Assert.NotNull(message);
        }

        [Fact]
        public void addAppointment()
        {
            AppointmentService appointmentService = new AppointmentService();
            ReservedAppointmentDTO reservedAppointmentDTO = new ReservedAppointmentDTO();
            reservedAppointmentDTO.DateFrom = "2022-06-20";
            reservedAppointmentDTO.DateTo = "2022-06-20";
            reservedAppointmentDTO.TimeFrom = "14:00";
            reservedAppointmentDTO.TimeTo = "15:00";
            reservedAppointmentDTO.Doctor = "Dragana Arsin";
            reservedAppointmentDTO.IsRated = false;
            reservedAppointmentDTO.Id = 2;
            reservedAppointmentDTO.Patient = "Kristina";

            appointmentService.addAppointment(reservedAppointmentDTO);
    }

    }
}
