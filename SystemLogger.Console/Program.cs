using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using SystemLogger.SendSysLog;

namespace SystemLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the a name for the first broadcast.");
            var userName = Console.ReadLine();
            var signal = new Transmit();
            Console.WriteLine(signal.AddBroadcastModel(userName));
            Console.WriteLine(signal.AddBroadcastModel("NewName", "192.168.15.255", 513));
            signal.Start();
        }
    }
}



