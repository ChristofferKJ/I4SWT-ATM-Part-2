using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    public class Airspace : IAirspace
    {
        public event EventHandler<LeaveEventArgs> RaisedLeaveEvent;
        protected virtual void OnRaisedLeaveEvent(LeaveEventArgs e)
        {
            RaisedLeaveEvent?.Invoke(this, e);
        }
        public const int SouthWest_Y = 10000;
        public const int SouthWest_X = 10000;
        public const int NorthEast_Y = 90000;
        public const int NorthEast_X = 90000;
        public const int MaxHeight = 20000;
        public const int MinHeight = 500;

        private readonly ICheckPlanes _cp; 

        public Airspace(ICheckPlanes cp)
        {
            _cp = cp;

        }

        public void CheckAirspace(List<IPlane> airspace)
        {
            foreach (var plane in airspace.ToList())
            {

                if (plane.XCoordinate < SouthWest_X || plane.YCoordinate < SouthWest_Y || plane.YCoordinate > NorthEast_Y || plane.XCoordinate >NorthEast_X || plane.Altitude < MinHeight || plane.Altitude > MaxHeight)
                {
                    if (CheckPlanes.ListOfTags.Contains(plane.Tag))
                    {
                        OnRaisedLeaveEvent(new LeaveEventArgs(plane, plane.TimeStamp.ToString()));
                        CheckPlanes.ListOfTags.Remove(plane.Tag);
                    }
                    airspace.Remove(plane);
                }
            }
            _cp.CheckPlanesInAirspace(airspace);
        }


    }
    public class LeaveEventArgs : EventArgs
    {
        public LeaveEventArgs(IPlane _plane1, string _timestamp)
        {
            Message = new Msg();
            Message.plane1 = _plane1;
            Message.timestamp = _timestamp;

        }

        public class Msg
        {
            public IPlane plane1;
            public string timestamp;
        }
        public Msg Message
        { get; set; }
    }   
}
