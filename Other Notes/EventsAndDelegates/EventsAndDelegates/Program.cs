using System;

namespace EventsAndDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserData userData = new UserData("Zekumoru");
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();
            publisher.UserDataProcessed += subscriber.OnUserDataProcessed;
            publisher.ProcessUserData(userData);
        }
    }
}