using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    interface IHandleRTD
    {
        void OnDataReady(object sender, RawTransponderDataEventArgs e);
        Plane Decode(string data); 
    }
}
