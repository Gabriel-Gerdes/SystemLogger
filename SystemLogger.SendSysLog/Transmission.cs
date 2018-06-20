using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SystemLogger.SendSysLog
{
    public class Transmission
    {
        //This Function outputs the transmission 

        public static bool BroadcastMessage(BroadcastModel Channel)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Gabriel J. Gerdes\Documents\GitHub\SystemLogger\SentMessages.txt", true))
            {
                Boolean exception_thrown = false;

                string text_to_send = ($"Message Start: {Channel.Message}");

                byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);
                file.WriteLine("*********************************************");
                file.WriteLine($"Broadcast Name: { Channel.BroadcastName}, Itteration: {Channel.MessageNumber}");
                file.WriteLine($"Sending to address: {Channel.Address}:{Channel.Port}");
                try
                {
                    Channel.SendingSocket.SendTo(send_buffer, Channel.SendingEndPoint);
                }
                catch (Exception send_exception)
                {
                    exception_thrown = true;
                    file.WriteLine($" Exception {send_exception.Message}");
                }
                if (exception_thrown == false)
                {
                    file.WriteLine("Message has been sent.");
                    Channel.MessageNumber = Channel.MessageNumber + 1;
                }
                else
                {
                    exception_thrown = false;
                    file.WriteLine("The exception indicates the message was not sent.\n");
                }
                return exception_thrown;
            }
        }
    }
}
