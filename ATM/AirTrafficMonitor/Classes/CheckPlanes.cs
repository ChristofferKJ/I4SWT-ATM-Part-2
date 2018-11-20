using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ATM;


namespace ATM
{
    public class CheckPlanes : ICheckPlanes
    {
        public event EventHandler<EnterEventArgs> RaisedEnterEvent;
        public List<string> ListOfTags;

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
            ListOfTags = new List<string>();
        }

        public void CheckPlanesInAirspace(List<IPlane> newplanes)
        {
            if (Planes.Count == 0)
            {
                foreach (var newplane in newplanes)
                {
                    newplane.IsInAirspace = true;
                    OnRaisedEnterEvent(new EnterEventArgs(newplane, newplane.TimeStamp.ToString()));
                    ListOfTags.Add(newplane.Tag);
                }
                
            }
            else
            {
                foreach (var newPlane in newplanes)
                {
                    if (ListOfTags.Contains(newPlane.Tag))
                    {
                        newPlane.IsInAirspace = true;
                        var plane = Planes.Find(x => x.Tag.Contains(newPlane.Tag));
                        _cc.CalcCourse(plane, newPlane);
                        _cv.CalcVelocity(plane, newPlane);
                    }
                    else
                    {
                        newPlane.IsInAirspace = true;
                        OnRaisedEnterEvent(new EnterEventArgs(newPlane, newPlane.TimeStamp.ToString()));
                        ListOfTags.Add(newPlane.Tag);
                    }
                }
            }
            
            Planes = newplanes;
            _rr.render(Planes);
        }

        public bool ContainsTagHelper(Plane oldPlane, Plane newPlane)
        {
            return oldPlane.Tag == newPlane.Tag;
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

