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
          foreach (IPlane plane1 in planes)
            {
                foreach (IPlane plane2 in planes)
                {
                    if (plane1 == plane2)
                    {
                        continue;
                    }
                    if (1==1 || Math.Abs(plane1.XCoordinate - plane2.XCoordinate) < 5000 &&
                        Math.Abs(plane1.YCoordinate - plane2.YCoordinate) < 5000 &&
                        Math.Abs(plane1.Altitude - plane2.Altitude) < 300) 
                    {
                        PassSepEvent(plane1, plane2, Convert.ToString(plane1.TimeStamp));
                        OnRaisedSerparationEvent(new SeperationsEventArgs(plane1,plane2, Convert.ToString(plane1.TimeStamp)));
                    }
                }
            }
        }
        public void PassSepEvent(IPlane plane1, IPlane plane2, string timestamp)
        {
            Log log = new Log();
            log.WriteToLog(plane1.Tag, plane2.Tag, timestamp);
        }

    }
    public class SeperationsEventArgs : EventArgs
    {
        public SeperationsEventArgs(IPlane _plane1, IPlane _plane2, string _timestamp)
        {
            Message = new Msg();
            Message.plane1 = _plane1;
            Message.plane2 = _plane2;
            Message.timestamp = _timestamp;
        }
        public class Msg
        {
            public IPlane plane1;
            public IPlane plane2;
            public string timestamp;
        }
        public Msg Message
        { get; set; }
    }
}
