using project_backend.DTO;
using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Adapter
{
    public class AppointmentFeedbackAdapter
    {
        public static AppointmentFeedback AppointmentFeedbackDTOToAppointmentFeedback(AppointmentFeedbackDTO appointmentFeedbackDTO)
        {
            AppointmentFeedback appointmentFeedback = new AppointmentFeedback();
            appointmentFeedback.Comment = appointmentFeedbackDTO.Comment;
            appointmentFeedback.Grade= Int32.Parse(appointmentFeedbackDTO.Grade);


            return appointmentFeedback;
        }
    }
}
