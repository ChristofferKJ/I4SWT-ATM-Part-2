using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class ATMApplication
    {
        static void Main()
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            CalculateVelocity cv = new CalculateVelocity();
            CalculateCourse cc = new CalculateCourse();
            Renedition rr = new Renedition();
            CheckPlanes As = new CheckPlanes(cv, cc, rr);
            Airspace SAs = new Airspace(As);

            var system = new HandleRTD(receiver, SAs);
            while (true)
                Thread.Sleep(5000);





        }
    }
}
