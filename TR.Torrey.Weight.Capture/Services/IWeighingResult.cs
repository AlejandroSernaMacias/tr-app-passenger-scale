using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Torrey.Weigh.Services
{
    public interface IWeighingResult
    {
        public void OnWeighingResult(Weight.Capture.Models.Weighing weighing);
    }
}
