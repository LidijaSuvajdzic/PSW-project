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
    public class PrescriptionController : ControllerBase
    {

       [HttpPost]
        [Route("addPrescription")]
        public IActionResult addPrescription([FromBody] PrescriptionDTO prescriptionDTO)
        {
            PrescriptionService prescriptionService = new PrescriptionService();
            prescriptionService.AddPrescription(prescriptionDTO);
            return Ok();

        }


    }
}
