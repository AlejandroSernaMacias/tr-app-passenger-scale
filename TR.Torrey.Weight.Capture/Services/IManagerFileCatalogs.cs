using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Torrey.Weight.Capture.Services
{
    public interface IManagerFileCatalogs
    {
        public void import(string pathFile);
        public void export(string pathFile);
    }
}
