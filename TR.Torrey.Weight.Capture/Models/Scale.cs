using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Torrey.Weight.Capture.Models
{
    public class Scale
    {
        public string vIp { get; set; }
        public string vPort { get; set; }
        public string vName { get; set; }
        public string fMinWeight { get; set; }
        public string fWeight { get; set; }
        public string fTotal { get; set; }
        public int iMinTime { get; set; }
        public int iSamples { get; set; }
        public int iStatus { get; set; }
        public string dtLastUpdate { get; set; }

        public string vStatusScale
        {
            get
            {
                string status = "ONLINE";

                if (iStatus == 0) status = "OFFLINE";
                else if (iStatus == 1) status = "ONLINE";

                return status;
            }
        }
        public string vStatusColor
        {
            get
            {
                string status = "DarkRed";

                if (iStatus == 0) status = "DarkRed";
                else if (iStatus == 1) status = "#009c36";

                return status;
            }
        }
    }
}
