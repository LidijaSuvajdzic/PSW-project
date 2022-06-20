using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.DTO
{
    public class HospitalFeedbackDTO
    {
        public int Id { get; set; }
        public String PatientName { get; set; }
        public String PatientLastname { get; set; }
        public String Grade { get; set; }
        public String Comment { get; set; }
        public bool IsAnonymously { get; set; }
        public bool IsPosted { get; set; }
    }
}
