using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ILeaveEvent
    {

        event EventHandler<LeaveEventArgs> RaisedLeaveEvent;

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
