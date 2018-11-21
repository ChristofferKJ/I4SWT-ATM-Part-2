using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;

namespace ATM
{
    public interface IEnterEvent
    {

        event EventHandler<EnterEventArgs> RaisedEnterEvent; 

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
            public string timestamp;
        }
        public Msg Message
        { get; set; }
    }
}
