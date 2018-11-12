using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{ 
    class DetectSeparationEvent : IDetectSeparationEvent
    {
        public void CheckSepEvent(List<Plane> planes)
        {
          foreach (Plane plane1 in planes)
            {
                foreach (Plane plane2 in planes)
                {
                    if (plane1 == plane2)
                    {
                        continue;
                    }
                    if (Math.Abs(plane1.XCoordinate - plane2.XCoordinate) < 5000 &&
                        Math.Abs(plane1.YCoordinate - plane2.YCoordinate) < 5000 &&
                        Math.Abs(plane1.Altitude - plane2.Altitude) < 300) 
                    {
                        PassSepEvent(plane1, plane2, Convert.ToString(plane1.TimeStamp));
                    }
                }
            }
        }
        void PassSepEvent(Plane plane1, Plane plane2, string timestamp)
        {
            Log log = new Log();
            log.WriteToLog(plane1.Tag, plane2.Tag, timestamp);

            Renedition renedition = new Renedition();
            renedition.CurSepEvent(plane1.Tag, plane2.Tag, timestamp);
        }
    }
}
