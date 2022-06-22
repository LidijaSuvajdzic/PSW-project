using project_backend.DTO;
using project_backend.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project_backendTests
{
    public class ReferralTests
    {
        [Fact]
        public void AddReferral()
        {
            ReferralService referralService = new ReferralService();
            ReferralDTO referralDTO = new ReferralDTO();
            referralDTO.Id = 8;
            referralDTO.SelectedSpecialist = "Stefan Simic";
            referralDTO.SelecterPatient = "Esma Simic";
            referralDTO.DoctorName = "Dragana";
            referralDTO.Reason = "Snimak pokazuje prelom ruke";


            referralService.addReferral(referralDTO);

        }
    }
}
