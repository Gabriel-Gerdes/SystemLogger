using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServiceLogger.Core
{
    public class ChannelModel
    {
        public UdpClient Client { get; private set; }
        public IPEndPoint IPEndPoint { get; private set; }
        public Guid ID { get; private set; }
        private int Port { get; set; }



        public ChannelModel(int _port)
        {
            IPEndPoint = new IPEndPoint(IPAddress.Any, _port);
            Client = new UdpClient(_port);
            ID = Guid.NewGuid();
        }


        public void ChangeIPAddress(string _ipAddress)
        {
            if (!IPAddress.TryParse(_ipAddress, out IPAddress newAddress))
            {
                throw new FormatException($"Invalid IP Address for Channel {ID}");
            }
            else
            {
                IPEndPoint = new IPEndPoint(newAddress, Port);
            }
        }
    }
}
