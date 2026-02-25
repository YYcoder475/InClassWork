using InClassWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            _users.Add(new AppUser { FirstName="Admin",UserEmail = "admin@mail.com", UserPassword = "admin", RegDate = DateTime.Now.ToShortDateString(), IsAdmin = true });
            _users.Add(new AppUser { FirstName = "TestingAdmin", UserEmail = "a", UserPassword = "a", IsAdmin = true, RegDate = DateTime.Now.ToShortDateString() });
            _users.Add(new AppUser { FirstName = "Pesent", UserEmail = "b", UserPassword = "b", IsAdmin = false, RegDate = DateTime.Now.ToShortDateString() });
            _users.Add(new AppUser { FirstName = "User1", UserEmail = "user1@mail.com", UserPassword = "pass1", IsAdmin = false, RegDate = DateTime.Now.ToShortDateString() });
            _users.Add(new AppUser { FirstName = "User2", UserEmail = "user2@mail.com", UserPassword = "pass2", IsAdmin = false, RegDate = DateTime.Now.ToShortDateString() });
            _users.Add(new AppUser { FirstName = "User3", UserEmail = "user3@mail.com", UserPassword = "pass3", IsAdmin = false, RegDate = DateTime.Now.ToShortDateString() });
            _users.Add(new AppUser { FirstName = "User4", UserEmail = "user4@mail.com", UserPassword = "pass4", IsAdmin = false, RegDate = DateTime.Now.ToShortDateString() });
            _users.Add(new AppUser { FirstName = "User5", UserEmail = "user5@mail.com", UserPassword = "pass5", IsAdmin = false, RegDate = DateTime.Now.ToShortDateString() });
        }

        public List<AppUser> GetUsers() { return _users; }

        public bool isExist(string uEmail, string uPass)
        {
            return _users.Any(u => u.UserEmail == uEmail && u.UserPassword == uPass);
        }

        public AppUser? GetUserByEmail(string uEmail)
        {
            return _users.FirstOrDefault( u => u.UserEmail == uEmail , null);
        }

        public void Insert(AppUser user)
        {
            if (user != null)
            {
                _users.Add(user);
            }
        }
        public void Delete(AppUser user)
        {
            if (user != null && _users.Contains(user))
            {
                _users.Remove(user);
            }
        }
        public void Update(AppUser user)
        {
            if (user != null && _users.Contains(user))
            {
                var index = _users.IndexOf(user);
                if (index >= 0)
                {
                    _users[index] = user;
                }
            }
        }
    }
}
