using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.DTO
{
    public class RequestSuggestionDTO
    {
        public String DateFrom { get; set; }
        public String DateTo { get; set; }
        public String TimeFrom { get; set; }
        public String TimeTo { get; set; }
        public String SelectedDoctor { get; set; }
        public String Priority { get; set; }
    }
}
