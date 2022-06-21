using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Models
{
    [Table("prescription")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("patientId")]
        public int PatientId { get; set; }
        [Column("doctorId")]
        public int DoctorId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("drug")]
        public String Drug { get; set; }
        [Column("usage")]
        public String Usage { get; set; }
    }
}
