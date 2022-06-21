using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public String Passwordd { get; set; }
        public int HealthCardNumber { get; set; }
        public string Role { get; set; }

    }
}
