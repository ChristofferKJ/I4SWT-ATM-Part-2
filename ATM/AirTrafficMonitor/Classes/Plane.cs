using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Plane
    {
        public string Tag { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int  Altitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Velocity { get; set; }
        public double Course { get; set; }
    }
}
