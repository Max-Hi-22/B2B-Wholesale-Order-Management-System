using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Threading.Tasks;
using DAL.Repositories;

namespace BLL.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepo;

        public AuthService()
        {
            _userRepo = new UserRepository();
        }

        public AuthService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public User LoginAdmin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Please provide both username and password.");
            }

            var user = _userRepo.GetUserByUsernameAndPassword(username.Trim(), password);
            
            if (user == null)
            {
                throw new UnauthorizedAccessException("Incorrect username or password.");
            }

            if (user.@lock)
            {
                throw new UnauthorizedAccessException("The account is locked. Please contact the administrator.");
            }

            if (!string.Equals(user.Role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("You do not have permission to access this resource.");
            }

            return user;
        }
    }
}
