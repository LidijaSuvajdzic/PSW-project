using project_backend.DTO;
using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Adapter
{
    public class PrescriptionAdapter
    {
        internal static PrescriptionDTO PrescriptionToPrescriptionDTO(Prescription prescription,User doctor,User patient)
        {
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO();
            prescriptionDTO.Id = prescription.Id;
            prescriptionDTO.Drug = prescription.Drug;
            prescriptionDTO.Usage = prescription.Usage;
            prescriptionDTO.Doctor = doctor.Firstname + " " + doctor.Lastname;
            prescriptionDTO.Patient = patient.Firstname + " " + patient.Lastname;
            return prescriptionDTO;
        }
    }
}
