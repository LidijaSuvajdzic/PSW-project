using project_backend.DTO;
using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Adapter
{
    public class UserAdapter
    {
            public static User UserDTOToUser(UserDTO dto)
            {
                User user = new User();
            user.Firstname = dto.Firstname;
            user.Lastname = dto.Lastname;
            user.Email = dto.Email;
            user.Passwordd = dto.Passwordd;
            user.Role = dto.Role;
            user.HealthCardNumber = dto.HealthCardNumber;
            return user;
            }

            public static UserDTO UserToUserDTO(User user)
            {
            UserDTO dto = new UserDTO();
            if (user.UserId != null) {
                dto.UserId = user.UserId;
            }
            dto.Firstname = user.Firstname;
            dto.Lastname = user.Lastname;
            dto.Email = user.Email;
            dto.Passwordd = user.Passwordd;
            dto.Role = user.Role;
            dto.HealthCardNumber = user.HealthCardNumber;

            return dto;
            }

    }
}
