using System;

namespace SystemLogger.SendSysLog.CLS
{
    class Program
    {
        static void Main(string[] args)
        {
            var signal = new Transmit();
            Console.WriteLine(signal.AddBroadcastModel("Message Number One"));

            Console.WriteLine("Please enter the a name for the first broadcast.");
            string userName = Console.ReadLine();
            //Console.WriteLine("Please enter an IP Address for your broadcast.");
            //string userIP = Console.ReadLine();

            try
            {
                Console.WriteLine(signal.AddBroadcastModel("Message Number One"));
                Console.WriteLine(signal.AddBroadcastModel(userName, "192.168.10.18", 513));
                signal.AddMessage("NewName", "This is a New Message");
                signal.Start();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"\n{exception.Message}");
                Console.Read();
            }

        }
    }
}
