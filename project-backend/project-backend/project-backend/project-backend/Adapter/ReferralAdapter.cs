using project_backend.DTO;
using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Adapter
{
    public class ReferralAdapter
    {
        public static Referral ReferralDTOToRefferal(int id, ReferralDTO referralDTO, User patient, User specialist, User doctor)
        {
            Referral referral = new Referral();
            referral.Id = id;
            referral.PatientId = patient.UserId;
            referral.SpecialistId = specialist.UserId;
            referral.DoctorId = doctor.UserId;
            referral.Reason = referralDTO.Reason;
            return referral;
        }
    }
}
