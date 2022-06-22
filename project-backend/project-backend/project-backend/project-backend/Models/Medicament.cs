using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Models
{
    [Table("medicaments")]
    public class Medicament
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("name")]
        public String Name { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
