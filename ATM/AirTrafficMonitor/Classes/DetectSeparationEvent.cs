using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{ 
    public class DetectSeparationEvent : IDetectSeparationEvent
    {
        public event EventHandler<SeperationsEventArgs> RaisedSerparationEvent;
        protected virtual void OnRaisedSerparationEvent(SeperationsEventArgs e)
        {
            RaisedSerparationEvent?.Invoke(this, e);
        }
        public void CheckSepEvent(List<IPlane> planes)

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
                        OnRaisedSerparationEvent(new SeperationsEventArgs(plane1,plane2, Convert.ToString(plane1.TimeStamp)));
                    }
                }
            }
        }
        public void PassSepEvent(Plane plane1, Plane plane2, string timestamp)
        {
            Log log = new Log();
            log.WriteToLog(plane1.Tag, plane2.Tag, timestamp);
        }

    }
    public class SeperationsEventArgs : EventArgs
    {
        public SeperationsEventArgs(Plane _plane1, Plane _plane2, string _timestamp)
        {
            Message = new Msg();
            Message.plane1 = _plane1;
            Message.plane2 = _plane2;
            Message.timestamp = _timestamp;
        }
        public class Msg
        {
            public Plane plane1;
            public Plane plane2;
            public string timestamp;
        }
        public Msg Message
        { get; set; }
    }
}
