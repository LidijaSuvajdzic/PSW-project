using project_backend.DTO;
using project_backend.Models;
using project_backend.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project_backendTests
{
    public class PrescriptionTests
    {
        [Fact]
        public void addPrescription()
        {
            PrescriptionService prescriptionService = new PrescriptionService();
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO();
            prescriptionDTO.Doctor = "Simonida Simic";
            prescriptionDTO.Patient = "Kristina Peric";
            prescriptionDTO.Drug = "Dexasol";
            prescriptionDTO.Usage = "Svaki dan po jednu tabletu";

            prescriptionService.AddPrescription(prescriptionDTO);
   
    }
    }
}
