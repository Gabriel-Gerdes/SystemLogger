using ServiceLogger.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SytemLogger.Services
{
    public class UDPServer
    {
        public List<ChannelModel> Channels { get; private set; }
        public List<PacketModel> Packets { get; private set; }

        public UDPServer()
            {
            Channels = new List<ChannelModel>();
            Packets = new List<PacketModel>();
            }
        public void Listen ()//ChannelModel channel, PacketModel packet)
        {
            ChannelModel channel = new ChannelModel(514);
            PacketModel packet = new PacketModel();
            bool done = false;
            byte[] receive_byte_array; //must use byte array for reciving.
            IPEndPoint groupEP = channel.IPEndPoint;
            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    receive_byte_array = channel.Client.Receive(ref groupEP);
                    Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
                    packet.Data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    Console.WriteLine("data follows \n{0}\n\n", packet.Data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            channel.Client.Close();
        }
    }
}
