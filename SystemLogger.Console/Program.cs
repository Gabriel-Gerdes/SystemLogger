using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using SystemLogger.SendSysLog;
using SytemLogger.Services;
using System.Threading;

namespace SystemLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var signal = new Transmit();


            Console.WriteLine("Please enter the a name for the first broadcast.");
            string userName = Console.ReadLine();
            //Console.WriteLine("Please enter an IP Address for your broadcast.");
            //string userIP = Console.ReadLine();

            try
            {
                Console.WriteLine(signal.AddBroadcastModel("Message Number One"));
                Console.WriteLine(signal.AddBroadcastModel(userName, "10.0.0.255", 514));
                signal.AddMessage("Message Number One", "This is a New Message");
                signal.Start();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"\n{exception.Message}");
                Console.Read();
            }
            */
            var input = new UDPServer();
            input.Listen();
        }
    }
}



