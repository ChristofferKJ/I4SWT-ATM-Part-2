//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ATM
//{
//    class DetectEnterEvent : IDetectEnterEvent
//    {
//        public event EventHandler<EnterEventArgs> RaisedEnterEvent;
//        protected virtual void OnRaisedEnterEvent(EnterEventArgs e)
//        {
//            RaisedEnterEvent?.Invoke(this, e);
//        }
//        public void CheckEnterEvent(List<IPlane> airspace, IPlane plane)
//        {
//            bool SameItem = airspace.Any(item => item.Tag == plane.Tag);

//            if (SameItem == false && plane.XCoordinate > 10000 || plane.YCoordinate > 10000 || plane.YCoordinate < 90000 || plane.XCoordinate < 90000 || plane.Altitude > 5000 || plane.Altitude < 20000)
//            {
//                OnRaisedEnterEvent(new EnterEventArgs(plane, plane.TimeStamp.ToString()));
//            }
//        }
//    }
//    public class EnterEventArgs : EventArgs
//    {
//        public EnterEventArgs(IPlane _plane1, string _timestamp)
//        {
//            Message = new Msg();
//            Message.plane1 = _plane1;
//            Message.timestamp = _timestamp;
//        }

//        public class Msg
//        {
//            public IPlane plane1;
//            public IPlane plane2;
//            public string timestamp;
//        }
//        public Msg Message
//        { get; set; }
//    }

//}

