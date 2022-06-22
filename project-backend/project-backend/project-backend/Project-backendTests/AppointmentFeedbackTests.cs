using project_backend.DTO;
using project_backend.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project_backendTests
{
    public class AppointmentFeedbackTests
    {
        [Fact]
        public void AddAppointmentFeedback()
        {
            AppointmentFeedbackService appointmentFeedbackService = new AppointmentFeedbackService();
            AppointmentFeedbackDTO appointmentFeedbackDTO = new AppointmentFeedbackDTO();
            appointmentFeedbackDTO.AppointmentId = 5;
            appointmentFeedbackDTO.Comment = "Komentarrr";
            appointmentFeedbackDTO.Grade ="3" ;
            appointmentFeedbackDTO.PatientName = "Kristina";
            appointmentFeedbackService.addAppointmentFeedback(appointmentFeedbackDTO);

    }
    }
}
