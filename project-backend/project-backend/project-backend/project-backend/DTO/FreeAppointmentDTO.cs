using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.DTO
{
    public class FreeAppointmentDTO
    {
        public int Id { get; set; }
        public String DateFrom { get; set; }
        public String DateTo { get; set; }

        public String Doctor { get; set; }
    }
}
