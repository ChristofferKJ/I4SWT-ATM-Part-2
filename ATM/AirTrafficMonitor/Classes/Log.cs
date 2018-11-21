using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    public class Log : ILog
    {
        public Log(DetectSeparationEvent detectSepEvent, Airspace detectLeaveEvent, CheckPlanes detectEnterEvent)
        {
            IDetectSeparationEvent DetectSepEvent;
            DetectSepEvent = detectSepEvent;
            DetectSepEvent.RaisedSerparationEvent += WriteSeperationToLog;

            IAirspace DetectLeaveEvent;
            DetectLeaveEvent = detectLeaveEvent;
            DetectLeaveEvent.RaisedLeaveEvent += WriteLeavingPlaneToLog;

            CheckPlanes DetectEnterEvent;
            DetectEnterEvent = detectEnterEvent;
            DetectEnterEvent.RaisedEnterEvent += WriteEnteredPlaneToLog;
        }

        public void WriteSeperationToLog(object sender, SeperationsEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The two planes {e.Message.plane1.Tag} and {e.Message.plane2.Tag} had a separation event at {e.Message.plane1.TimeStamp}");
            }
        }

        public void WriteEnteredPlaneToLog(object sender, EnterEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The plane {e.Message.plane1.Tag} has entered the airspace, at {e.Message.plane1.TimeStamp}");
            }
        }

        public void WriteLeavingPlaneToLog(object sender, LeaveEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The plane {e.Message.plane1.Tag} has left the airspace, at {e.Message.plane1.TimeStamp}");
            }
        }

        public void ClearLog()
        {
            using (StreamWriter sw = new StreamWriter("Log.txt"))
            {
                sw.Write("");
            }
        }
    }
}
   
