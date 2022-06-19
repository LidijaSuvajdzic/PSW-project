using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Repository
{
    public class AppointmentRepository : IDisposable
    {
        private readonly MyWebApiContext _context;

        public AppointmentRepository(MyWebApiContext context)
        {
            _context = context;
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

        internal List<FreeAppointment> findAppoinments(DateTime dateFrom, DateTime dateTo, int id)
        {
            List < FreeAppointment > lists = (from s in _context.freeAppointments
                           where s.DoctorId == id && s.DateFrom<=dateFrom && s.DateTo>=dateTo
                           select s).ToList();
            return lists;
        }


        public List<FreeAppointment> findAppoinmentsByDoctor(int id)
        {
            List<FreeAppointment> lists = (from s in _context.freeAppointments
                                           where s.DoctorId == id
                                           select s).ToList();
            return lists;
        }

        public List<FreeAppointment> findAppoinmentsByDate(DateTime dateFrom, DateTime dateTo)
        {
            List<FreeAppointment> lists = (from s in _context.freeAppointments
                                           where s.DateFrom >= dateFrom && s.DateTo <= dateTo
                                           select s).ToList();
            return lists;
        }
    }
}

