using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Torrey.Weight.Capture.Services
{
    public interface IDialogAlert
    {
        public void showSimpleDialogAlert(string message);
        public void showScaleList();
    }
}
