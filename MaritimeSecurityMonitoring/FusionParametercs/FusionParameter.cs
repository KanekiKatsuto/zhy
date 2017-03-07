using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaritimeSecurityMonitoring
{
    class FusionParameter
    {
        public float? xyzParameter { get; set; }
        public float? abrDistance { get; set; }
        public float? abrAngle { get; set; }
        public long? radarMiss { get; set; }
        public long? AISMiss { get; set; }
        public long? IM { get; set; }
        public long? IN { get; set; }
    }
}
