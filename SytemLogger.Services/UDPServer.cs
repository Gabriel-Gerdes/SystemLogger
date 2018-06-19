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
        public void Listen (ChannelModel channel, PacketModel packet)
        {   
            byte[] receive_byte_array; //must use byte array for reciving.
            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    receive_byte_array = listener.Receive(ref groupEP);
                    Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    Console.WriteLine("data follows \n{0}\n\n", received_data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            listener.Close();
        }
    }
}
