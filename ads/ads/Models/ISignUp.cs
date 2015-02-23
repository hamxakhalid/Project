using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ads.Models
{
    public interface ISignUp
    {
        void IsignUp(User u);
        bool ICheckUserName(string UserName);
        bool loginUser(User user);
        int UserId(string s);
    }
}
