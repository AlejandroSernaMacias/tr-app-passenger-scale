using AP.Data.Transfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Torrey.Weight.Capture.Models
{
    public class SocketSettings
    {
        public TRSocket socket { get; set; }
        public string name { get; set; } = "";
        public string ip { get; set; } = "";
        public int port { get; set; }
        public string endControl { get; set; } = "CR";
        public Dictionary<string, char> endControls { get; set; }

        public SocketSettings()
        {
            endControls = new Dictionary<string, char> { { "CR", '\r' } };
        }

        public char GetEndControl()
        {
            return endControls[endControl];
        }

        public bool HasEndControlCharacter(string data)
        {
            return (data.IndexOf(GetEndControl()) > -1) ? true : false;
        }

    }
}
