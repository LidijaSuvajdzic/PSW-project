using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Repository
{
    public class AppointmentFeedbackRepository: IDisposable
    {

        private readonly MyWebApiContext _context;

        public AppointmentFeedbackRepository(MyWebApiContext context)
        {
            _context = context;
        }


        public void AddAppointmentFeedback(AppointmentFeedback appointmentFeedback)
        {
            if (appointmentFeedback != null)
            {
                _context.appointmentFeedbacks.Add(appointmentFeedback);
                _context.SaveChanges();
            }
        }

        public List<AppointmentFeedback> GetAllAppointmentFeedbacks()
        {
            return _context.appointmentFeedbacks.ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

    }
}
