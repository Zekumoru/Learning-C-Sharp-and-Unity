using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    internal class UserData
    {
        public UserData(string userName)
        {
            UserName = userName;
        }

        public string? UserName { get; set; }
    }
}
