using System.Linq;
using Pajutrao_Project.Models;

namespace Pajutrao_Project.Services
{
    public interface IUserService
    {
        bool ValidateUser(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly FourtifyContext _context;

        public UserService(FourtifyContext context)
        {
            _context = context;
        }

        public bool ValidateUser(string username, string password)
        {
            // Fetch the user from the database (without case-sensitive comparison)
            var user = _context.Accounts
                .FirstOrDefault(a => a.AccName == username);

            // If user is found, perform case-sensitive check on both username and password
            if (user != null && string.Equals(user.AccName, username, StringComparison.Ordinal)
                && string.Equals(user.AccPass, password, StringComparison.Ordinal))
            {
                return true;
            }

            return false;
        }
    }
}
