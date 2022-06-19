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
    }
}
