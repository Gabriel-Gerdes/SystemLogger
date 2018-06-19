using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemLogger.SendSysLog
{
    public class Transmit
    {
        public List<BroadcastModel> BroadcastModels { get; private set;}

        public Transmit() {
            BroadcastModels = new List<BroadcastModel>();
        }

        public void Start() {
            if (BroadcastModels != null)
            {
                //TODO figure out the best way to kill this loop.
                while (true)
                {
                    foreach (var i in BroadcastModels)
                    {
                        Transmission.BroadcastMessage(i);
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                throw new ArgumentException($"{nameof(BroadcastModels)} cannot be null or empty.");
            }
        }

        //Function Adds a Broadcast to the list of BroadcastModels.
        //Returns a string declaring if the addition was successful or not.
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

        //Overload used when the user wishes it create a Broadcast with a spcific Address and port.
        //Returns a string declaring if the addition was successful or not.
        public string AddBroadcastModel(string name, string IPAddress, int port) {
            string _returnMessage;

            //Checks to see if the desired name is alread used. 
            //This is only used if the UI requests userinput instead of a list when deleting or editing the Broadcasts.
            if (BroadcastModels.Find(x => x.BroadcastName == name) == null)
            {
                var _newBroadcastModel = new BroadcastModel(name);
                _newBroadcastModel.AddIPAddress(IPAddress);
                _newBroadcastModel.AddPort(port);
                BroadcastModels.Add(_newBroadcastModel);
                _returnMessage = "Channel Added.";
            }
            else
            {
                _returnMessage = "Failed to add Channel.";
            }
                return _returnMessage;
        }

        //function Deletes a Broadcast Model from BroadcastModels.
        //Returns a string declaring it was successful or returns an updated thrown exception.
        public String DeleteBroadcastModel(string name) {
            try
            {
                BroadcastModels.Remove(BroadcastModels.Find(x => x.BroadcastName == name));
                return  "Channel Deleted.";
            }
            catch (Exception exception)
            {
                throw new Exception($"Exception: {exception.Message} \nFailed to Delete Channel.");
            }
        }

        //Overload used if the UI provides a list of possible Broadcasts instead of asking for a typed response.
        //Returns a string declaring it was successful or returns an updated thrown exception.
        public String DeleteBroadcastModel(Guid id)
        {
            try
            {
                BroadcastModels.Remove(BroadcastModels.Find(x => x.ID == id));
                return "Channel Deleted.";
            }
            catch (Exception exception)
            {
                //Adds "Failed to Delete" to a thrown exception.
                throw new Exception($"Exception: {exception.Message} \nFailed to Delete Broadcast.");
            }
        }

        //Function Adds a message to a spacific Broadcast
        //Returns a string detailing if it was successful. 
        public String AddMessage(string name, string message) {
            string _returnMessage;

            //Looks for a Broadcast Model with the Identifying name.
            var model = BroadcastModels.FirstOrDefault(x => x.BroadcastName == name);

            if (model != null)
            {
                model.Message = message;
                _returnMessage = "Message Added.";
            }
            else
            {
                _returnMessage = "Failed to add message. \n No existing Broadcast.";
            }
            return _returnMessage;
        }

        //Overload used if the UI provides a list of possible BroadcastModels instead of asking for a typed response.
        public String AddMessage(Guid id, string message)
        {
            string _returnMessage;
            var model = BroadcastModels.FirstOrDefault(x => x.ID == id);

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
