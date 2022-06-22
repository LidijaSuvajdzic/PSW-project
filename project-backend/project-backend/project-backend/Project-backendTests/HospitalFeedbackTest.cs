using project_backend.DTO;
using project_backend.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace Project_backendTests
{
    public class HospitalFeedbackTest
    {
        [Fact]
        public void AddFeedback()
        {
            HospitalFeedbackService hospitalFeedbackService = new HospitalFeedbackService();
            HospitalFeedbackDTO hospitalFeedbackDTO = new HospitalFeedbackDTO();
            hospitalFeedbackDTO.Id = 10;
            hospitalFeedbackDTO.PatientName = "Kristina";
            hospitalFeedbackDTO.PatientLastname = "Peric";
            hospitalFeedbackDTO.Grade = "4";
            hospitalFeedbackDTO.Comment = "uzivancija";
            hospitalFeedbackDTO.IsAnonymously = true;

            hospitalFeedbackService.addHospitalFeedbackFeedback(hospitalFeedbackDTO);
        }

        [Fact]
        public void getAll()
        {
            HospitalFeedbackService hospitalFeedbackService = new HospitalFeedbackService();
            List<HospitalFeedbackDTO> list = hospitalFeedbackService.GetAllHospitalFeedback();

            Assert.NotNull(list);
        }

        [Fact]
        public void setPublic()
        {
            HospitalFeedbackService hospitalFeedbackService = new HospitalFeedbackService();
            int id= 1;
            hospitalFeedbackService.setPublic(1);
        }

        [Fact]
        public void removePublic()
        {
            HospitalFeedbackService hospitalFeedbackService = new HospitalFeedbackService();
            int id = 1;
            hospitalFeedbackService.removePublic(1);
        }
    }
}
