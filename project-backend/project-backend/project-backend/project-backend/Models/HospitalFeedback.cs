using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Models
{
    [Table("hospitalFeedback")]
    public class HospitalFeedback
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("patientId")]
        public int PatientId { get; set; }

        [Column("grade")]
        public int Grade { get; set; }
        [Column("comment")]
        public String Comment { get; set; }
        [Column("isAnonymously")]
        public bool IsAnonymously { get; set; }
        [Column("isAPosted")]
        public bool IsPosted { get; set; }
    }
}
