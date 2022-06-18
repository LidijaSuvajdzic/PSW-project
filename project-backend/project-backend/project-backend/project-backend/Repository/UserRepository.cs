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


        public User FindUserByEmail(string email) {

            var student = (from s in _context.users
                           where s.Email == email
                           select s).FirstOrDefault<User>();
            return student;
        }

        public List<User> FindUsersByRole(string role)
        {

            List<User> users = (from s in _context.users
                           where s.Role == role
                           select s).ToList();
            return users;
        }


        public List<User> GetAllUsers()
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
