using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TR.Torrey.Weight.Capture.Models
{
    public class TRSocket : Socket
    {
        public string name { get; set; } = "";
        public string uuid { get; set; } = "";
        public string ip { get; set; } = "";

        public TRSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) : base(addressFamily, socketType, protocolType)
        {
        }
    }
}
