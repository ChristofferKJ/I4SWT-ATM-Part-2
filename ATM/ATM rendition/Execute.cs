using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class Execute
    {
        public static void RunATM()
        {
            Renedition ren = new Renedition();
            DetectSeparationEvent detect = new DetectSeparationEvent();            
            
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            CalculateVelocity cv = new CalculateVelocity();
            CalculateCourse cc = new CalculateCourse();
            CheckPlanes As = new CheckPlanes(cv, cc, ren);
            Airspace SAs = new Airspace(As);
            Renedition renedition = new Renedition(detect, As, SAs);
            Log log = new Log(detect, SAs, As);

            var system = new HandleRTD(receiver, SAs, detect);
            while (true)
                Thread.Sleep(5000);
        }
    }
}
