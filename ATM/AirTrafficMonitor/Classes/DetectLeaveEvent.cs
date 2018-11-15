using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class DetectTrackLeftAirspaceEvent
    {
        public void CheckLeaveEvent(List<Plane> airspace)
        {
            foreach (Plane plane in airspace)
            {
                if (plane.XCoordinate < 10000 || plane.YCoordinate < 10000 || plane.YCoordinate > 90000 || plane.XCoordinate > 90000 || plane.Altitude < 5000 || plane.Altitude > 20000)
                {
                    PassLeaveEvent(plane, Convert.ToString(plane.TimeStamp));
                }
            }
        }
        void PassLeaveEvent(Plane plane1, string timestamp)
        {
            Log log = new Log();
            log.WriteLeavingPlaneToLog(plane1.Tag, timestamp);
            //Log log = new Log();
            //log.WriteLeavingPlaneToLog(plane1.Tag, timestamp);

            Renedition renedition = new Renedition();
            renedition.CurLeavingEvent(plane1.Tag, timestamp);
            //Renedition renedition = new Renedition();
            //renedition.CurLeavingEvent(plane1.Tag, timestamp);
        }
    }
}
