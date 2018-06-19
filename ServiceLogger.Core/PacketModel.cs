using System;
using System.Net;

namespace ServiceLogger.Core
{
    public class PacketModel
    {
        public Guid ID { get; private set; }
        public DateTime DateTime { get; private set; }
        public string DataType { get; private set; }
        public int SourcePort { get; private set; }
        public int DestinationPort { get; private set; }
        public string Data { get; set; }

    }   
}
