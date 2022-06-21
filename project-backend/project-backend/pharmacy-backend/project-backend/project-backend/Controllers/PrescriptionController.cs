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

        [Route("findPrescription/{id}")]
        [HttpGet]
        public IActionResult findprescription(int id)
        {
            PrescriptionService prescriptionService = new PrescriptionService();
            PrescriptionDTO prescriptionDTO =prescriptionService.GetPrescription(id);
            return Ok(prescriptionDTO);
        }

    }
}
