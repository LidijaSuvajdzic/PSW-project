using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Repository
{
    public class PenalRepository:IDisposable
    {
        private readonly MyWebApiContext _context;

        public PenalRepository(MyWebApiContext context)
        {
            _context = context;
        }


        private bool disposed = false;

        public List<Penal> GetAllPenals()
        {
            return _context.penals.ToList();
        }

        internal void addPenal(Penal penal)
        {
            if (penal != null)
            {
                _context.penals.Add(penal);
                _context.SaveChanges();
            }
        }

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

        public List<Penal> findPenalsByDate(DateTime today, DateTime monthAgo, int userId)
        {
                List<Penal> penals = (from s in _context.penals
                                      where s.PatientId==userId && s.Date<=today && s.Date>=monthAgo
                                      select s).ToList() ;
                return penals;
            
        }
    }
}
