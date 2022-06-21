using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Repository
{
    public class PrescriptionRepository: IDisposable
    {
        private readonly MyWebApiContext _context;

        public PrescriptionRepository(MyWebApiContext context)
        {
            _context = context;
        }


        private bool disposed = false;

        internal void addPrescription(Prescription prescription)
        {
            if (prescription != null)
            {
                _context.prescriptions.Add(prescription);
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

        public List<Prescription> getAllPrescription()
        {
            return _context.prescriptions.ToList();
        }
    }
}
