using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    internal class Publisher
    {
        const int ProcessingSimulationSeconds = 3000;

        public delegate void UserDataProcessedEventHandler(object source, UserDataProcessedEventArgs args);
        public event UserDataProcessedEventHandler? UserDataProcessed;
        
        public void ProcessUserData(UserData userData)
        {
            Console.WriteLine("Processing user data...");
            Thread.Sleep(ProcessingSimulationSeconds);

            OnUserDataProcessed(userData);
        }

        protected virtual void OnUserDataProcessed(UserData userData)
        {
            UserDataProcessed?.Invoke(this, new UserDataProcessedEventArgs() { UserData = userData });
        }
    }
}
