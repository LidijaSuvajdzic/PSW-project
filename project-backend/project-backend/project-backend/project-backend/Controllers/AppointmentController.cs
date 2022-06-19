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
    }
}
