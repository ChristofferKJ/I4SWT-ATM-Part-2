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
            DetectSeparationEvent detect = new DetectSeparationEvent();
            Renedition renedition = new Renedition(detect);
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            CalculateVelocity cv = new CalculateVelocity();
            CalculateCourse cc = new CalculateCourse();                
            CheckPlanes As = new CheckPlanes(cv, cc, renedition);
            Airspace SAs = new Airspace(As);
            
            var system = new HandleRTD(receiver, SAs, detect);
            while (true)
                Thread.Sleep(5000);
        }
    }
}
