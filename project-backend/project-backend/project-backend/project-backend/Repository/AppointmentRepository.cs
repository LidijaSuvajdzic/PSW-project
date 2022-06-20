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
                           where s.DoctorId == id && s.DateFrom<=dateFrom && s.DateTo>=dateTo && s.IsFree==true
                           select s).ToList();
            return lists;
        }

        public FreeAppointment findAppoinment(DateTime dateFrom, DateTime dateTo, int id)
        {
            FreeAppointment fa = (from s in _context.freeAppointments
                                           where s.DoctorId == id && s.DateFrom <= dateFrom && s.DateTo >= dateTo && s.IsFree == true
                                           select s).FirstOrDefault<FreeAppointment>(); ;
            return fa;
        }

        public ReservedAppointment findAppointmentById( int id)
        {
            ReservedAppointment ap = (from s in _context.reservedAppointments
                                               where s.Id == id
                                               select s).FirstOrDefault<ReservedAppointment>();
            return ap;
        }
        public FreeAppointment find(int id)
        {
            FreeAppointment fa = (from s in _context.freeAppointments
                                  where s.Id==id
                                  select s).FirstOrDefault<FreeAppointment>(); ;
            return fa;
        }

        public ReservedAppointment findReservedAppointment(int id)
        {
            ReservedAppointment fa = _context.reservedAppointments.Find(id);
            return fa;
        }

        public List<FreeAppointment> findAppoinmentsByDoctor(int id)
        {
            List<FreeAppointment> lists = (from s in _context.freeAppointments
                                           where s.DoctorId == id && s.IsFree == true
                                           select s).ToList();
            return lists;
        }


        public List<ReservedAppointment> findMyFutureAppointments(DateTime dateNow,int id)
        {
            List<ReservedAppointment> lists = (from s in _context.reservedAppointments
                                           where s.DateFrom>=dateNow && s.PatientId==id
                                           select s).ToList();
            return lists;
        }

        public List<ReservedAppointment> findMyPreviousAppointments(DateTime dateNow, int id)
        {
            List<ReservedAppointment> lists = (from s in _context.reservedAppointments
                                               where s.DateTo <= dateNow && s.PatientId == id
                                               select s).ToList();
            return lists;
        }


        public List<FreeAppointment> findAppoinmentsByDate(DateTime dateFrom, DateTime dateTo)
        {
            List<FreeAppointment> lists = (from s in _context.freeAppointments
                                           where s.DateFrom >= dateFrom && s.DateTo <= dateTo && s.IsFree == true
                                           select s).ToList();
            return lists;
        }


        public List<ReservedAppointment> GetAllReservedAppointments()
        {
            return _context.reservedAppointments.ToList();
        }

        public void AddAppointment(ReservedAppointment reservedAppointment)
        {
            if (reservedAppointment != null)
            {
                _context.reservedAppointments.Add(reservedAppointment);
                _context.SaveChanges();
            }
        }

        public void UpdateFreeAppointment(FreeAppointment freeAppointment)
        {
            if (freeAppointment != null)
            {
                _context.freeAppointments.Update(freeAppointment);
                _context.SaveChanges();
            }
        }

        

        public void UpdateReservedAppointment(ReservedAppointment reservedAppointment)
        {
            if (reservedAppointment != null)
            {
                _context.reservedAppointments.Update(reservedAppointment);
                _context.SaveChanges();
            }
        }

        public FreeAppointment findAppoinmentByDate(DateTime dateFrom, DateTime dateTo)
        {
            FreeAppointment freeAppointment = (from s in _context.freeAppointments
                                      where s.DateFrom==dateFrom && s.DateTo==dateTo
                                      select s).FirstOrDefault<FreeAppointment>();
            return freeAppointment;
        }

        internal void deleteReservedAppointment(ReservedAppointment reservedAppointment)
        {
            _context.reservedAppointments.Remove(reservedAppointment);
            _context.SaveChanges();
        }
    }
}

