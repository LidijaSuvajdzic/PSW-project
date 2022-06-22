using project_backend.Models;
using project_backend.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project_backendTests
{
    public class PenalTests
    {
        [Fact]
        public void checkMalicious()
        {
            PenalService penalService = new PenalService();
            UserService userService = new UserService();
            User u = userService.findById(1);
            penalService.checkMalicious(u);

        }
    }
}
