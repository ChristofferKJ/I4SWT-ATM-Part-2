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
        public Log(IDetectSeparationEvent detectSepEvent, IAirspace detectLeaveEvent, ICheckPlanes detectEnterEvent)
        {
            IDetectSeparationEvent DetectSepEvent;
            DetectSepEvent = detectSepEvent;
            DetectSepEvent.RaisedSerparationEvent += WriteSeperationToLog;

            IAirspace DetectLeaveEvent;
            DetectLeaveEvent = detectLeaveEvent;
            DetectLeaveEvent.RaisedLeaveEvent += WriteLeavingPlaneToLog;

            ICheckPlanes DetectEnterEvent;
            DetectEnterEvent = detectEnterEvent;
            DetectEnterEvent.RaisedEnterEvent += WriteEnteredPlaneToLog;
        }

        public void WriteSeperationToLog(object sender, SeperationsEventArgs e)
        {
            WriteToLog(e.Message.plane1.Tag, e.Message.plane2.Tag, e.Message.timestamp.ToString());
        }

        public void WriteEnteredPlaneToLog(object sender, EnterEventArgs e)
        {
            WriteEnteredToLog(e.Message.plane1.Tag, e.Message.timestamp.ToString());
        }

        public void WriteLeavingPlaneToLog(object sender, LeaveEventArgs e)
        {
            WriteLeavingToLog(e.Message.plane1.Tag,e.Message.timestamp.ToString());
        }
        public void WriteToLog(string planeTagA, string planeTagB, string timeOfOccurrence)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The two planes {planeTagA} and {planeTagB} had a separation event at {timeOfOccurrence}");
            }
        }

        public void WriteEnteredToLog(string planeTag, string timeOfOccurrence)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The plane {planeTag} has entered the airspace, at {timeOfOccurrence}");
            }
        }
        public void WriteLeavingToLog(string planeTag, string timeOfOccurrence)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The plane {planeTag} has left the airspace, at {timeOfOccurrence}");
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
