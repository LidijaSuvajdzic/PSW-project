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


        public int GenerateId()
        {
            int number= _userRepository.GetAllEmployee().Count + 1;
            Debug.WriteLine("Broj je" + number);
            return number;
        }

    }
}
