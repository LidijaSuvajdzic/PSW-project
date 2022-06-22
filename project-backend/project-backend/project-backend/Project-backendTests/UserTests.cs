using project_backend.DTO;
using project_backend.Models;
using project_backend.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project_backendTests
{
    public class UserTests
    {
        [Fact]
        public void findById()
        {
            UserService userService = new UserService();
            User u =userService.findById(1);
            Assert.NotNull(u);
        }

        [Fact]
        public void unBlock()
        {
            UserService userService = new UserService();
            userService.unBlock(1);
        }

        [Fact]
        public void block()
        {
            UserService userService = new UserService();
            userService.block(1);
        }

        [Fact]
        public void dontBlock()
        {
            UserService userService = new UserService();
            userService.dontBlock(1);
        }

        [Fact]
        public void findAllBlockedUsers()
        {
            UserService userService = new UserService();
            List<UserDTO> users = userService.findAllBlockedUsers();
            Assert.NotNull(users);
        }

        [Fact]
        public void findAllMaliciousUsers()
        {
            UserService userService = new UserService();
            List<UserDTO> users = userService.findAllMaliciousUsers();
            Assert.NotNull(users);
        }

        [Fact]
        public void findAllUsersByRole()
        {
            UserService userService = new UserService();
            List<UserDTO> users = userService.FindUsersByRole("ROLE_DOCTOR");
            Assert.NotNull(users);
        }

        [Fact]
        public void authenticate()
        {
            UserService userService = new UserService();
            string email = "suvajdziclidija@gmail.com";
            string password = "1234567890";
            userService.Authenticate(email,password);
        }

        [Fact]
        public void isUserExist()
        {
            UserService userService = new UserService();
            string email = "suvajdziclidija@gmail.com";
            userService.IsUserExist(email);
        }

        [Fact]
        public void isBlocked()
        {
            UserService userService = new UserService();
            string email = "suvajdziclidija@gmail.com";
            string password = "1234567890";
            bool isBlocked = userService.isBlocked(email,password);
            Assert.NotNull(isBlocked);

        }

        [Fact]
        public void Register()
        {
            UserService userService = new UserService();
            User user = new User();
            user.UserId = 100;
            user.Firstname = "Persida";
            user.Lastname = "Katic";
            user.Email = "persidakatic@gmail.com";
            user.Passwordd = "Persida123!";
            user.HealthCardNumber = 321123543;
            user.Role = "ROLE_PATIENT";
            user.IsBlocked = false;
            user.Penals = 0;
            user.IsPotentiallyMalicious = false;
            userService.Register(user);

        }
    }
}
