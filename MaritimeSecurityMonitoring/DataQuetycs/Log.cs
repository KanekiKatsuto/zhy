using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaritimeSecurityMonitoring
{
    class Log
    {
        public string time { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string MMSI { get; set; }
        public string navigationalStatus { get; set; }
        public string toRate { get; set; }
        public string speed { get; set; }
    }
}
