using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.DTO
{
    public class ReservedAppointmentDTO
    {
        public bool IsRated;

        public int Id { get; set; }
        public String DateFrom { get; set; }
        public String DateTo { get; set; }
        public String TimeFrom { get; set; }
        public String TimeTo { get; set; }
        public String Doctor { get; set; }

        public String Patient { get; set; }
    }
}
