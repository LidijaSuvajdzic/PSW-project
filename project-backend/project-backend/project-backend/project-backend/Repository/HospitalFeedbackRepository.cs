using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Repository
{
    public class HospitalFeedbackRepository: IDisposable
    {
        private readonly MyWebApiContext _context;

        public HospitalFeedbackRepository(MyWebApiContext context)
        {
            _context = context;
        }


        public void AddHospitalFeedback(HospitalFeedback hospitalFeedback)
        {
            if (hospitalFeedback != null)
            {
                _context.hospitalFeedback.Add(hospitalFeedback);
                _context.SaveChanges();
            }
        }

        public HospitalFeedback  FindById(int id)
        {
            HospitalFeedback hospitalFeedback= _context.hospitalFeedback.Find(id);
            return hospitalFeedback;
        }

        public void UpdateHospitalFeedback(HospitalFeedback hospitalFeedback)
        {
            _context.hospitalFeedback.Update(hospitalFeedback);
            _context.SaveChanges();
        }

        public List<HospitalFeedback> GetAllHospitalFeedbacks()
        {
            return _context.hospitalFeedback.ToList();
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
