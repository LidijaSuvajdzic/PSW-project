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
            hospitalFeedbackService.addHospitalFeedbackFeedback(hospitalFeedbackDTO);
            return Ok();
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult getAll()
        {
            HospitalFeedbackService hospitalFeedbackService = new HospitalFeedbackService();
            List<HospitalFeedbackDTO> list = hospitalFeedbackService.GetAllHospitalFeedback();
            return Ok(list);
        }

        [HttpPost]
        [Route("setPublic/{id}")]
        public IActionResult setPublic(String id)
        {
            int ID = Int32.Parse(id);
            HospitalFeedbackService hospitalFeedbackService = new HospitalFeedbackService();
            hospitalFeedbackService.setPublic(ID);
            return Ok();
        }

        [HttpPost]
        [Route("removePublic/{id}")]
        public IActionResult removePublic(String id)
        {
            int ID = Int32.Parse(id);
            HospitalFeedbackService hospitalFeedbackService = new HospitalFeedbackService();
            hospitalFeedbackService.removePublic(ID);
            return Ok();
        }

    }
}
