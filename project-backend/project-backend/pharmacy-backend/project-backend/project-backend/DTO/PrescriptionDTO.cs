using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public String Patient { get; set; }
        public String Doctor { get; set; }
        public String Drug { get; set; }
        public String Usage { get; set; }
    }
}
