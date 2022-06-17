using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using project_backend.Adapter;
using project_backend.DTO;
using project_backend.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public UserController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserDTO newUser)
        {
            UserService userService = new UserService();
            userService.Register(UserAdapter.UserDTOToUser(newUser));

            return Ok();
        }
    }
}
