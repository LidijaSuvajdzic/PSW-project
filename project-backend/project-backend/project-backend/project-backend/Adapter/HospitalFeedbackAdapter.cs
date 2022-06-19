using project_backend.DTO;
using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Adapter
{
    public class HospitalFeedbackAdapter
    {
        public static HospitalFeedback HospitalFeedbackDTOToHospitalFeedback(HospitalFeedbackDTO hospitalFeedbackDTO)
        {
            HospitalFeedback hospitalFeedback = new HospitalFeedback();
            hospitalFeedback.Comment = hospitalFeedbackDTO.Comment;
            hospitalFeedback.Grade = Int32.Parse(hospitalFeedbackDTO.Grade);
            if (hospitalFeedbackDTO.IsAnonymously == "Yes")
            {
                hospitalFeedback.IsAnonymously = true;
            }
            else {
                hospitalFeedback.IsAnonymously = false;
            }

            return hospitalFeedback;
        }
    }
}
