using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using project_backend.DTO;
using project_backend.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AppointmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        public IActionResult cheking([FromBody] CheckingAppointmentDTO checkingAppointmentDTO)
        {
            AppointmentService appointmentService = new AppointmentService();
            String message = appointmentService.checkAvailability(checkingAppointmentDTO);
                return Ok(message);
            
        }

        [HttpDelete]
        [Route("delete/{id}/{firstname}/{lastname}")]
        public IActionResult delete(int id,String firstname,String lastname)
        {
            AppointmentService appointmentService = new AppointmentService();
            Debug.WriteLine("Id je" + id);
            string message = appointmentService.checkDates(id);
            if (message=="You can't cancel the appointment!") {
                return BadRequest();
            } else {
                appointmentService.cancelAppointment(id,firstname,lastname);
               return Ok();
            }
            

        }


        [HttpPost]
        [Route("suggestAppointments")]
        public IActionResult suggestAppointments([FromBody] RequestSuggestionDTO requestSuggestionDTO)
        {
            String priority = requestSuggestionDTO.Priority;
            AppointmentService appointmentService = new AppointmentService();
            String message = "";
            List<FreeAppointmentDTO> freeAppointmentDTOs = new List<FreeAppointmentDTO>();
            if (priority == "Doctor") {
                message=appointmentService.findMessageForFindingAppointmentsByDoctor(requestSuggestionDTO);
                freeAppointmentDTOs = appointmentService.findAppointmentByDoctor(requestSuggestionDTO);
            } 
            else {
                message = appointmentService.findMessageForFindingAppointmentsByTime(requestSuggestionDTO);
                freeAppointmentDTOs = appointmentService.findAppointmentByDate(requestSuggestionDTO);
            }
            if (message == "No appointments found") {
                return BadRequest();
            } else {
                return Ok(freeAppointmentDTOs);
            }
        }



        
        [HttpGet]
        [Route("findAppointments/{selectedDoctor}")]
        public IActionResult findAppointments(String selectedDoctor)
        {
            AppointmentService appointmentService = new AppointmentService();
            List<FreeAppointmentDTO> lists = appointmentService.findAppointmentBySpecialist(selectedDoctor);
            return Ok(lists);
            
        }




        [HttpPost]
        [Route("addAppointment")]
        public IActionResult addAppointment([FromBody] ReservedAppointmentDTO reservedAppointmentDTO)
        {
            AppointmentService appointmentService = new AppointmentService();
            appointmentService.addAppointment(reservedAppointmentDTO);
            return Ok();
        }

        [HttpPost]
        [Route("addAppointmentFromTable/{id}/{patient}")]
        public IActionResult addAppointmentFromTable(int id,String patient)
        {
            Debug.WriteLine("ispisi id"+id);
            AppointmentService appointmentService = new AppointmentService();
            appointmentService.addAppointmentFromTable(id,patient);
            return Ok();
        }

        [HttpGet]
        [Route("findPreviousAppointments/{firstname}")]
        public IActionResult findPreviousAppointments(String firstname)
        {
            Debug.WriteLine("ime je" + firstname);
            AppointmentService appointmentService = new AppointmentService();
            List<ReservedAppointmentDTO> lists = appointmentService.findMyPreviousAppointments(firstname);
            return Ok(lists);
        }

        [HttpGet]
        [Route("findFutureAppointments/{firstname}")]
        public IActionResult findFutureAppointments(String firstname)
        {
            Debug.WriteLine("ime je" + firstname);
            AppointmentService appointmentService = new AppointmentService();
            List<ReservedAppointmentDTO> lists = appointmentService.findMyFutureAppointments(firstname);
            return Ok(lists);
        }

    }
}
