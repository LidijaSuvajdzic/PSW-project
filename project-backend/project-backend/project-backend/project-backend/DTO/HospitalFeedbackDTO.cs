using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.DTO
{
    public class HospitalFeedbackDTO
    {
        public String PatientName { get; set; }
        public String Grade { get; set; }
        public String Comment { get; set; }
        public String IsAnonymously { get; set; }
    }
}
