using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using project_backend.Adapter;
using project_backend.DTO;
using project_backend.Models;
using project_backend.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace project_backend.Service
{
    public class UserService
    {

        private UserRepository _userRepository;

        public UserService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<MyWebApiContext>();
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            builder.UseNpgsql(connectionString);
            _userRepository = new UserRepository(new MyWebApiContext(builder.Options));
        }
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(User user)
        {
            user.UserId = GenerateId();
            _userRepository.AddUser(user);
        }

        public bool IsUserExist(string email)
        {
            bool isExists = false;
            User u = _userRepository.FindUserByEmail(email);
            if (u != null) {
                isExists = true;
            }

            return isExists;
        }

        internal object Authenticate(string email, string passwordd)
        {
            User u = _userRepository.FindUserByEmail(email);
            if (u == null) {
                return u;
            }
            if (u.Passwordd != passwordd) {
                u = null;
            }
                return u;
        }

        public int GenerateId()
        {
            int number= _userRepository.GetAllUsers().Count + 1;
            return number;
        }


        public List<UserDTO> FindUsersByRole(string role) {
            List<User> users = _userRepository.FindUsersByRole(role);
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (User u in users) {
                userDTOs.Add(UserAdapter.UserToUserDTO(u));
            }
            return userDTOs;
        }



        public string GenerateToken(int userId)
        {
            var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
            var myIssuer = "http://mysite.com";
            var myAudience = "http://myaudience.com";
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
