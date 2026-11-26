using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository
    {
        private readonly B2BWholesaleDBEntities _context;

        public UserRepository()
        {
            _context = new B2BWholesaleDBEntities();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return _context.Users.FirstOrDefault(u => 
                u.UserName == username && 
                u.password == password
            );
        }

        public User getUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }
    }
}
