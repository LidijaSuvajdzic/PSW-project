using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using project_backend.Adapter;
using project_backend.DTO;
using project_backend.Service;
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

            bool isBlocked = userService.isBlocked(loginUserDTO.Email, loginUserDTO.Passwordd);
            if (isBlocked) {
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

        [Route("findAllDoctors")]
        [HttpGet]
        public IActionResult findAllDoctors()
        {
            UserService userService = new UserService();
            string role = "DOCTOR";
            List<UserDTO> usersDTO = userService.FindUsersByRole(role);

            return Ok(usersDTO);
        }

        [Route("findAllMaliciousUsers")]
        [HttpGet]
        public IActionResult findAllMaliciousUsers()
        {
            UserService userService = new UserService();
            List<UserDTO> usersDTO = userService.findAllMaliciousUsers();

            return Ok(usersDTO);
        }


        [Route("findBlockedUsers")]
        [HttpGet]
        public IActionResult findAlBlockedUsers()
        {
            UserService userService = new UserService();
            List<UserDTO> usersDTO = userService.findAllBlockedUsers();

            return Ok(usersDTO);
        }

        [Route("block/{id}")]
        [HttpPost]
        public IActionResult block(int id)
        {
            UserService userService = new UserService();
            userService.block(id);
            return Ok();
        }

        [Route("dontBlock/{id}")]
        [HttpPost]
        public IActionResult dontBlock(int id)
        {
            UserService userService = new UserService();
            userService.dontBlock(id);
            return Ok();
        }

        [Route("unBlock/{id}")]
        [HttpPost]
        public IActionResult unBlock(int id)
        {
            UserService userService = new UserService();
            userService.unBlock(id);
            return Ok();
        }


        [Route("findAllSpecialists")]
        [HttpGet]
        public IActionResult findAllSpecialists()
        {
            UserService userService = new UserService();
            string role = "SPECIALIST";
            List<UserDTO> usersDTO = userService.FindUsersByRole(role);

            return Ok(usersDTO);
        }

        [Route("findAllPatients")]
        [HttpGet]
        public IActionResult findAllPatients()
        {
            UserService userService = new UserService();
            string role = "PATIENT";
            List<UserDTO> usersDTO = userService.FindUsersByRole(role);

            return Ok(usersDTO);
        }
    }
}
