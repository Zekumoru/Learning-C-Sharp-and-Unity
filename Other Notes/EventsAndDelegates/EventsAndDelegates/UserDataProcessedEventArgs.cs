using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    internal class UserDataProcessedEventArgs : EventArgs
    {
        public UserData? UserData { get; set; }
    }
}
