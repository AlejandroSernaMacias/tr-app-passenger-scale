using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using TR.Torrey.Weight.Capture.Dao;
using TR.Torrey.Weight.Capture.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;

namespace TR.Torrey.Weight.Capture.Repositories
{
    public class ScaleRepository
    {
        public static Task<string> save(Models.Scale scale)
        {
                return ScaleDao.save(scale);
        }
        public static Task<string> delete(Models.Scale scale)
        {
            return ScaleDao.delete(scale);
        }
        public static async Task<string> scales()
        {
            return await ScaleDao.scales();
        }
    }
}
