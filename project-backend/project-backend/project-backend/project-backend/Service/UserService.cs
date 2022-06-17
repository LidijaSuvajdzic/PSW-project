using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using project_backend.Models;
using project_backend.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        public UserService(UserRepository employeeRepository)
        {
            _userRepository = employeeRepository;
        }

        public void Register(User user)
        {
            user.UserId = GenerateId();
            _userRepository.AddEmployee(user);
        }

        public bool IsUserExist(string email)
        {
            Debug.WriteLine("Email koji se trazi je " + email);
            bool isExists = false;
            User u = _userRepository.FindUserByEmail(email);
            if (u != null) {
                Debug.WriteLine("Nasli smo usera"+ u.Email + u.Firstname);
                isExists = true;
            }

            return isExists;
        }


        public int GenerateId()
        {
            int number= _userRepository.GetAllEmployee().Count + 1;
            return number;
        }

        public void FindUserByEmail(string email) {
           User u = _userRepository.FindUserByEmail(email);
           Debug.WriteLine("User je" + u.Firstname);
        }


    }
}
