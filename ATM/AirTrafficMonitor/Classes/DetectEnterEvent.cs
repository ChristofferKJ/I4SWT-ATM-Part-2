using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class DetectEnterEvent
    {
        public void CheckEnterEvent(List<Plane> airspace, Plane plane)
        {
            bool SameItem = airspace.Any(item => item.Tag == plane.Tag);

            if (SameItem == false && plane.XCoordinate > 10000 || plane.YCoordinate > 10000 || plane.YCoordinate < 90000 || plane.XCoordinate < 90000 || plane.Altitude > 5000 || plane.Altitude < 20000)
            {
                PassEnterEvent(plane, Convert.ToString(plane.TimeStamp));
            }
        }
    }
        void PassEnterEvent(Plane plane1, string timestamp)
        {
            Log log = new Log();
            log.WriteEnteredPlaneToLog(plane1.Tag, timestamp);
        //    Log log = new Log();
        //    log.WriteEnteredPlaneToLog(plane1.Tag, timestamp);

            Renedition renedition = new Renedition();
            renedition.CurEnterEvent(plane1.Tag, timestamp);
        //    Renedition renedition = new Renedition();
        //    renedition.CurEnterEvent(plane1.Tag, timestamp);
        }

    }
}
