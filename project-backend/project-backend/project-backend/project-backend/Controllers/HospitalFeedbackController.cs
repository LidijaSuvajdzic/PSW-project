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
    public class HospitalFeedbackController : ControllerBase
    {
        [HttpPost]
        [Route("addHospitalFeedback")]
        public IActionResult addAppointmentFeedback([FromBody] HospitalFeedbackDTO hospitalFeedbackDTO)
        {
            HospitalFeedbackService hospitalFeedbackService = new HospitalFeedbackService();
            hospitalFeedbackService.addAppointmentFeedback(hospitalFeedbackDTO);
            return Ok();
        }

    }
}
