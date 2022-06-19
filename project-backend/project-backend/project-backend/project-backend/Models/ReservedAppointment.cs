using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Models
{
    [Table("reservedAppointment")]
    public class ReservedAppointment
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("dateFrom")]
        public DateTime DateFrom { get; set; }
        [Column("dateTo")]
        public DateTime DateTo { get; set; }
        [Column("doctorId")]
        public int DoctorId { get; set; }
        [Column("patientId")]
        public int PatientId { get; set; }
    }
}
