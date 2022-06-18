using Microsoft.AspNetCore.Authorization;
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
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

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

        [HttpPost]
        public IActionResult Register([FromBody] UserDTO newUser)
        {
            UserService userService = new UserService();        
            bool isExists = userService.IsUserExist(newUser.Email);
            if (isExists) {
                return BadRequest();
            } else {
                userService.Register(UserAdapter.UserDTOToUser(newUser));
                return Ok();
            }
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginUserDTO loginUserDTO)
        {
            UserService userService = new UserService();

            bool isExists = userService.IsUserExist(loginUserDTO.Email);
            if (!isExists) {
                return BadRequest();
            }

            var userDTO = UserAdapter.UserToUserDTO((Models.User)userService.Authenticate(loginUserDTO.Email, loginUserDTO.Passwordd));  

            if (userDTO == null)
                return BadRequest();

            var tokenString = userService.GenerateToken(userDTO.UserId);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = userDTO.UserId,
                Role = userDTO.Role,
                FirstName = userDTO.Firstname,
                LastName = userDTO.Lastname,
                Token = tokenString
            });
        }
    }
}
