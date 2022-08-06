using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CpmPedidos.Repository
{
    public static class DateUtils
    {
        public static bool DataCompleta(DateTime data)
        {
            Regex ok = new Regex(@"(\d{2}\/\d{2}\/\d{4} \d{2}:\d{2})");
            return ok.Match(data.ToString()).Success;
        }
        public static bool DataPura(DateTime data)
        {
            Regex ok = new Regex(@"(\d{2}\/\d{2}\/\d{4})");
            return ok.Match(data.Date.ToString()).Success;
        }
    }
}
