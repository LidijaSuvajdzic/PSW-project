using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Repository
{
    public class ReferralRepository:IDisposable
    {
        private readonly MyWebApiContext _context;

        public ReferralRepository(MyWebApiContext context)
        {
            _context = context;
        }


        private bool disposed = false;

        public List<Referral> GetAllReferrals()
        {
            return _context.referrals.ToList();
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

        internal void addReferral(Referral referral)
        {
            if (referral != null)
            {
                _context.referrals.Add(referral);
                _context.SaveChanges();
            }
        }
    }
}
