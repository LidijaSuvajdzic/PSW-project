using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using project_backend.Adapter;
using project_backend.DTO;
using project_backend.Models;
using project_backend.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Service
{
    public class PrescriptionService
    {
        private PrescriptionRepository _prescriptionRepository;
        private UserRepository _userRepository;

        public PrescriptionService()
       {        }

        public PrescriptionService(PrescriptionRepository prescriptionRepository, UserRepository userRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _userRepository = userRepository;
        }


        public PrescriptionDTO GetPrescription(int id)
        {
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository();
            UserRepository userRepository = new UserRepository();
            Task<Prescription> prescriptionTask = prescriptionRepository.Get(id);
            Prescription prescription = prescriptionTask.Result;
            User patient = userRepository.Get(prescription.PatientId).Result;
            User doctor = userRepository.Get(prescription.DoctorId).Result;
            PrescriptionDTO prescriptionDTO = PrescriptionAdapter.PrescriptionToPrescriptionDTO(prescription,doctor,patient);

            return prescriptionDTO;
        }
    }
}
