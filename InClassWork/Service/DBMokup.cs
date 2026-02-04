using InClassWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWork.Service
{
    public class DBMokup
    {
        private List<AppUser> _users = new List<AppUser>();
        public DBMokup()
        {
            _users.Add(new AppUser { UserEmail = "admin@mail.com", UserPassword = "admin", IsAdmin = true });
            _users.Add(new AppUser { UserEmail = "a", UserPassword = "a", IsAdmin = true });
            _users.Add(new AppUser { UserEmail = "b", UserPassword = "b", IsAdmin = false });
            _users.Add(new AppUser { UserEmail = "user1@mail.com", UserPassword = "pass1", IsAdmin = false });
            _users.Add(new AppUser { UserEmail = "user2@mail.com", UserPassword = "pass2", IsAdmin = false });
        }
        public bool isExist(string uEmail, string uPass)
        {
            return _users.Any(u => u.UserEmail == uEmail && u.UserPassword == uPass);
        }
    }
}
