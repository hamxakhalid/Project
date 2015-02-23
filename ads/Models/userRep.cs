using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ads.Models
{
    public class userRep:ISignUp
    {
        public void IsignUp(User u)
        {
            var cx = new Database1Entities8();
            cx.Users.Add(u);
            cx.SaveChanges();
        }
        public bool loginUser(User user)
        {
            var db = new Database1Entities8();
            int i = db.Users.Where(z => z.UserName.Equals(user.UserName) && z.Password.Equals(user.Password)).Count();
            if (i == 1)
            {
                return true;
            }
            else
                return false;
        
        }
        public bool ICheckUserName(string UserName)
        {
            var cx = new Database1Entities8();
            int i = cx.Users.Where(u => u.UserName.Equals(UserName)).Count();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int UserId(string s)
        {
            var cx = new Database1Entities8();
            var q = cx.Users.Where(a => a.UserName.Equals(s)).Select(a => new { a.Id });
            foreach (var x in q)
            {
                return x.Id;
            }
            return 0;
        }
    }
}