using project_backend.DTO;
using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Adapter
{
    public class FreeAppointmentAdapter
    {

        public static FreeAppointmentDTO FreeAppointmentToFreeAppointmentDTO(FreeAppointment freeAppointment)
        {
            FreeAppointmentDTO dto = new FreeAppointmentDTO();
            dto.Id = freeAppointment.Id;
            dto.DateFrom = freeAppointment.DateFrom.ToString();
            dto.DateTo = freeAppointment.DateTo.ToString();
            return dto;
        }


    }
}
