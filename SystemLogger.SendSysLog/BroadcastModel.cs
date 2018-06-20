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

        public BroadcastModel(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"{nameof(name)} cannot be null or empty.");

            MessageNumber = 0;

            Port = 514;
            Address = IPAddress.Broadcast;
            SendingEndPoint = new IPEndPoint(Address, Port);
            SendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            SendingSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            BroadcastName = name;
            ID = Guid.NewGuid();
            Message = "No message assigned.";            
        }

        public void NewMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                Message = "Invalid message assigned";
            else Message = message;
        }

        public void AddSendingEndPoint(string address, int port) {
            AddIPAddress(address);
            AddPort(port);
        }

        public void AddIPAddress(string address)
        {

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException($"{nameof(address)} cannot be null or empty.");
            }
            else
            {
                if (!IPAddress.TryParse(address, out IPAddress newAddress))
                {
                    throw new FormatException($"Invalid IPAddress for Broadcast {BroadcastName} ID: {ID}");
                }
                else
                {
                    Address = newAddress;
                    SendingEndPoint = new IPEndPoint(Address, Port);
                }
            }    
        }

        public void AddPort(int port)
        {
            Port = port;
            SendingEndPoint = new IPEndPoint(Address, Port);
        }

        public void AddSocket(Socket socket)
        {
            SendingSocket = socket;
        }
    } 
}
