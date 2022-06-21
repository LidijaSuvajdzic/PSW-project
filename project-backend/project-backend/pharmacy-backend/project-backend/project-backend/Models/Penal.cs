using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Models
{
    [Table("penals")]
    public class Penal
    {
        [Column("penalId")]
        public int PenalId { get; set; }
        [Column("patientId")]
        public int PatientId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
