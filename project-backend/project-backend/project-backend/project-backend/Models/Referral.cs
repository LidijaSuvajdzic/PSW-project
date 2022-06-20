using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Models
{
    [Table("referrals")]
    public class Referral
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("patientId")]
        public int PatientId { get; set; }
        [Column("doctorId")]
        public int DoctorId { get; set; }
        [Column("specialistId")]
        public int SpecialistId { get; set; }
        [Column("reason")]
        public String Reason { get; set; }

    }
}
