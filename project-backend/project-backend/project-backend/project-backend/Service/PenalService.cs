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
    public class PenalService
    {
        private PenalRepository _penalRepository;
        private UserRepository _userRepository;
        private AppointmentRepository _appointmentRepository;

        public PenalService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<MyWebApiContext>();
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            builder.UseNpgsql(connectionString);
            _penalRepository = new PenalRepository(new MyWebApiContext(builder.Options));
            _userRepository = new UserRepository(new MyWebApiContext(builder.Options));
            _appointmentRepository = new AppointmentRepository(new MyWebApiContext(builder.Options));
        }

        public PenalService(PenalRepository penalRepository, UserRepository userRepository, AppointmentRepository appointmentRepository)
        {
            _penalRepository = penalRepository;
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
        }

        public int GenerateId()
        {
            int number = _penalRepository.GetAllPenals().Count + 10;
            return number;
        }

        public void checkMalicious(User patient)
        {
            DateTime today = DateTime.Now;
            DateTime monthAgo = today.AddMonths(-1);

            int counter = _penalRepository.findPenalsByDate(today,monthAgo,patient.UserId).Count;
            Debug.WriteLine("BROJ OTKAZANIH PREGLEDA U MESEC DANA JE"+ counter);
            if (counter >=3) {
                patient.IsPotentiallyMalicious = true;
                _userRepository.UpdateUser(patient);
            }
        }
    }
}
