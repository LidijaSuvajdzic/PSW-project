using project_backend.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Models

{
    [Table("users")]
    public class User
    {
        [Column("userid")]
        public int UserId { get; set; }
        [Column("firstname")]
        public String Firstname { get; set; }
        [Column("lastname")]
        public String Lastname { get; set; }
        [Column("email")]
        public String Email { get; set; }
        [Column("password")]
        public String Passwordd { get; set; }
        [Column("healthcardnumber")]
        public int HealthCardNumber { get; set; }
        [Column("role")]
        public string Role { get; set; }
    }
}
