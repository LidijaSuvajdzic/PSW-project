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
    [Route("api/[controller]/")]
    [ApiController]
    public class ReferralController : ControllerBase
    {

        [HttpPost]
        [Route("addReferral")]
        public IActionResult addReferral([FromBody] ReferralDTO referralDTO)
        {
            ReferralService referralService = new ReferralService();
            referralService.addReferral(referralDTO);
            return Ok();

        }
    }
}
