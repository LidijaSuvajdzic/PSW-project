using project_backend.DTO;
using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Adapter
{
    public class ReservedAppointmentAdapter
    {
        public static ReservedAppointment ReservedAppointmentDTOToReservedAppointment(ReservedAppointmentDTO reservedAppointmentDTO)
        {
            ReservedAppointment reservedAppointment = new ReservedAppointment();

            String datefrom = reservedAppointmentDTO.DateFrom + " " + reservedAppointmentDTO.TimeFrom + ":00";
            String dateto = reservedAppointmentDTO.DateTo + " " + reservedAppointmentDTO.TimeTo + ":00";

            reservedAppointment.DateFrom= DateTime.ParseExact(datefrom, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
           reservedAppointment.DateTo = DateTime.ParseExact(dateto, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
            if (reservedAppointmentDTO.Id != null) {
                reservedAppointment.Id = reservedAppointmentDTO.Id;
            }

            return reservedAppointment;
        }

        public static ReservedAppointmentDTO ReservedAppointmentToReservedAppointmentDTO(ReservedAppointment reservedAppointment)
        {
            ReservedAppointmentDTO reservedAppointmentDTO = new ReservedAppointmentDTO();

            if (reservedAppointment.Id != null)
            {
                reservedAppointmentDTO.Id = reservedAppointment.Id;
            }

            reservedAppointmentDTO.DateFrom = reservedAppointment.DateFrom.ToString();
            reservedAppointmentDTO.DateTo = reservedAppointment.DateTo.ToString();
            if (reservedAppointment.IsRated != null) {
                reservedAppointmentDTO.IsRated = reservedAppointment.IsRated;
            }
            return reservedAppointmentDTO;
        }
    }
}
