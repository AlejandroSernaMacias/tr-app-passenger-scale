using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Torrey.Weight.Capture.Models
{
    public class Scale: INotifyPropertyChanged
    {
        public string vName { get; set; }
        public string vIp { get; set; }
        public string fMinWeight { get; set; }

        private string _fWeight;
        public string fWeight
        {
            get => _fWeight;
            set
            {
                if (_fWeight != value)
                {
                    _fWeight = value;
                    OnPropertyChanged(nameof(fWeight));
                }
            }
        }

        private int _iStatus;
        public int iStatus
        {
            get => _iStatus;
            set
            {
                if (_iStatus != value)
                {
                    _iStatus = value;
                    OnPropertyChanged(nameof(iStatus));
                }
            }
        }

        private int _iSamples;
        public int iSamples
        {
            get => _iSamples;
            set
            {
                if (_iSamples != value)
                {
                    _iSamples = value;
                    OnPropertyChanged(nameof(iSamples));
                }
            }
        }

        private string _fTotal;
        public string fTotal
        {
            get => _fTotal;
            set
            {
                if (_fTotal != value)
                {
                    _fTotal = value;
                    OnPropertyChanged(nameof(fTotal));
                }
            }
        }

        public string vPort { get; set; }
        public int iMinTime { get; set; }
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



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}