using project_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_backend.Repository
{
    public class UserRepository : IDisposable
    {
        private readonly MyWebApiContext _context;

        public UserRepository(MyWebApiContext context)
        {
            _context = context;
        }

        public void AddEmployee(User user)
        {
            if (user != null)
            {
                _context.users.Add(user);
                _context.SaveChanges();
            }
        }

        public List<User> GetAllEmployee()
        {
            return _context.users.ToList();
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
