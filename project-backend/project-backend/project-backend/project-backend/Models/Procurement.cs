using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Models
{
    [Table("procurements")]
    public class Procurement
    {
            [Column("procurementId")]
            public int ProcurementId { get; set; }
            [Column("medicamentName")]
            public String MedicamentName { get; set; }
            [Column("quantity")]
            public int Quantity { get; set; }
        }
}
