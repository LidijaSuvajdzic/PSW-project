using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_backend.DTO;
using project_backend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentFeedbackController : ControllerBase
    {

        [HttpPost]
        [Route("addAppointmentFeedback")]
        public IActionResult addAppointmentFeedback([FromBody] AppointmentFeedbackDTO appointmentFeedbackDTO)
        {
            AppointmentFeedbackService appointmentFeedbackService = new AppointmentFeedbackService();
            appointmentFeedbackService.addAppointmentFeedback(appointmentFeedbackDTO);
            return Ok();
        }
    }
}
