using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemLogger.SendSysLog
{
    public class Transmit
    {
        public List<BroadcastModel> BroadcastModels { get; private set;}
        private Boolean Kill { get; set; }

        public Transmit() {
            BroadcastModels = new List<BroadcastModel>();
            Kill = false;
        }

        public void Start() {
            var transmission = new Transmission();
            if (BroadcastModels != null)
            {
                //TODO figure out the best way to kill this loop.
                while (!Kill)
                {
                    foreach (var i in BroadcastModels)
                    {
                        System.Threading.Thread.Sleep(2500);
                        transmission.BroadcastMessage(i);
                    }
                }
            }
            else
            {
                throw new ArgumentException($"{nameof(BroadcastModels)} cannot be null or empty.");
            }
        }

        public string AddBroadcastModel(string name)
        {
            string _returnMessage;
            if (BroadcastModels.FirstOrDefault(x => x.BroadcastName == name) == null)
            {
                BroadcastModels.Add(new BroadcastModel(name));
                _returnMessage = "Channel Added.";
            }
            else
            {
                _returnMessage = "Failed to add Channel.";
            }
            return _returnMessage;
        }

        public string AddBroadcastModel(string name, string IPAddress, int port) {
            string _returnMessage;
            if (BroadcastModels.Find(x => x.BroadcastName == name) == null)
            {
                var _newBroadcastModel = new BroadcastModel(name);
                _newBroadcastModel.AddIPAddress(IPAddress);
                _newBroadcastModel.AddPort(port);
                BroadcastModels.Add(new BroadcastModel(name));
                _returnMessage = "Channel Added.";
            }
            else
            {
                _returnMessage = "Failed to add Channel.";
            }
                return _returnMessage;
        }

        public String DeleteBroadcastModel(string name) {
            string _returnMessage;
            try
            {
                BroadcastModels.Remove(BroadcastModels.Find(x => x.BroadcastName == name));
                _returnMessage = "Channel Deleted.";
            }
            catch (Exception exception)
            {
                Console.WriteLine($" Exception {exception.Message}");
                _returnMessage = "Failed to Delete Channel.";
            }
            return _returnMessage;
        }

        public String AddMessage(string name, string message) {
            string _returnMessage;
            var model = BroadcastModels.FirstOrDefault(x => x.BroadcastName == name);

            if (model != null)
            {
                model.Message = message;
                _returnMessage = "Message Added.";
            }
            else
            {
                _returnMessage = "Failed to add message.";
            }
            return _returnMessage;
        }
    }
}
