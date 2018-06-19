using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SystemLogger.SendSysLog
{
    public class Transmission
    {
        //This Function outputs the transmission 
        public void BroadcastMessage(BroadcastModel Channel)
        {
            Boolean exception_thrown = false;

            string text_to_send = ($"You are brodcasting on port {Channel.Port}, under the IP address {Channel.Address}. \n Message Start: {Channel.Message}");

            byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);
            Console.WriteLine($"\nBroadcast Name: { Channel.BroadcastName}, Itteration: {Channel.MessageNumber}");
            Console.WriteLine($"Sending to address: {Channel.Address}, Port: {Channel.Port}");
            try
            {
                Channel.SendingSocket.SendTo(send_buffer, Channel.SendingEndPoint);
            }
            catch (Exception send_exception)
            {
                exception_thrown = true;
            Console.WriteLine($" Exception {send_exception.Message}");
            }
            if (exception_thrown == false)
            {
                Console.WriteLine("Message has been sent to the broadcast address");
                Channel.MessageNumber = Channel.MessageNumber + 1;
            }
            else
            {
                exception_thrown = false;
            Console.WriteLine("The exception indicates the message was not sent.");
            }
        }
    }
}
