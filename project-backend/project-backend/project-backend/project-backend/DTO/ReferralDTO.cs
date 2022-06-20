using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.DTO
{
    public class ReferralDTO
    {
   
        public int Id { get; set; }
        public String SelectedSpecialist { get; set; }
        public String SelecterPatient { get; set; }
        public String Reason { get; set; }
        public String DoctorName { get; set; }
    }
}
