using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using project_backend.Adapter;
using project_backend.DTO;
using project_backend.Models;
using project_backend.Service;
using System;
using System.Collections.Generic;


namespace project_backend.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public UserController(IConfiguration configuration) {
            _configuration = configuration;
        }



        [Route("findUser/{id}")]
        [HttpGet]
        public IActionResult findUser(int id)
        { 
             UserService userService = new UserService();
             UserDTO user =userService.GetUser(id);
            return Ok(user);
        }
    }
}
