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

        }
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        public UserDTO GetUser(int id)
        {
            UserRepository userRepository = new UserRepository();
            User u = userRepository.Get(id).Result;
            UserDTO userDTO = UserAdapter.UserToUserDTO(u);

            return userDTO;
        }


    }
}
