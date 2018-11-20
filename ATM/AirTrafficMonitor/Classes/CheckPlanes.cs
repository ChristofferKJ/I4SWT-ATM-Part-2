using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    public class CheckPlanes : ICheckPlanes
    {
        public event EventHandler<EnterEventArgs> RaisedEnterEvent;
        protected virtual void OnRaisedEnterEvent(EnterEventArgs e)
        {
            RaisedEnterEvent?.Invoke(this, e);
        }
        public List<IPlane> Planes { get; set; }

        private ICalculateVelocity _cv;
        private ICalculateCourse _cc;
        private IRenedition _rr; 

        public CheckPlanes(ICalculateVelocity cv, ICalculateCourse cc, IRenedition rr)
        {
            _cc = cc;
            _cv = cv;
            _rr = rr;
            Planes = new List<IPlane>();
        }

        public void CheckPlanesInAirspace(List<IPlane> newplanes)
        {
            foreach (var newplane in newplanes)
            {
                if (!Planes.Contains(newplane))
                {
                    OnRaisedEnterEvent(new EnterEventArgs(newplane, newplane.TimeStamp.ToString()));
                }
                
                foreach (var plane in Planes)
                {
                    if (newplane == plane)
                    {
                        _cc.CalcCourse(plane, newplane);
                        _cv.CalcVelocity(plane, newplane);
                        continue;
                    }
                }
                
            }
            
            Planes = newplanes;
            _rr.render(Planes);
        }
    }
    public class EnterEventArgs : EventArgs
    {
        public EnterEventArgs(IPlane _plane1, string _timestamp)
        {
            Message = new Msg();
            Message.plane1 = _plane1;
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

