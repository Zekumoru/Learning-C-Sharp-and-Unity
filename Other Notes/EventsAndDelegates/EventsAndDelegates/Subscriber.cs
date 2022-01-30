using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    internal class Subscriber
    {
        public void OnUserDataProcessed(object source, UserDataProcessedEventArgs args)
        {
            Console.WriteLine($"I got notified you finished processing {args.UserData?.UserName} data!");
        }
    }
}
