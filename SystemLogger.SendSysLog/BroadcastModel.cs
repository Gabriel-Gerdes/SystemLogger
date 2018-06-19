using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SystemLogger.SendSysLog
{
    public class BroadcastModel
    {
        public Guid ID { get; private set; }
        public String BroadcastName { get; private set; }
        public IPAddress Address { get; private set; }
        public int Port { get; private set; }
        public String Message { get; set; }
        public long MessageNumber { get; set; }
        public Socket SendingSocket { get; private set; }
        public IPEndPoint SendingEndPoint { get; private set; }

        public BroadcastModel(String name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException($"{nameof(name)} cannot be null or empty.");

            MessageNumber = 0;

            Port = 514;
            Address = IPAddress.Broadcast;

            SendingEndPoint = new IPEndPoint(Address, Port);
            SendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            ID = Guid.NewGuid();
            BroadcastName = name;
            Message = "No message assigned.";            
        }

        public void AddIPAddress(String address)
        {

            if (String.IsNullOrEmpty(address))
                throw new ArgumentException($"{nameof(address)} cannot be null or empty.");
            else
            {
                Address = null;
                Address = IPAddress.Parse(address);

            }
        }

        public void NewMessage(String message)
        {
            if (String.IsNullOrEmpty(message))
                Message = "Invalid message assigned";
            else Message = message;
        }


        public void AddPort(int port)
        {

            Port = port;
            SendingEndPoint = new IPEndPoint(Address, Port);
        }
    }
}
