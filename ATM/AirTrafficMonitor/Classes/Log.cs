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
            WriteToLog(e.Message.plane1.Tag, e.Message.plane2.Tag, e.Message.timestamp.ToString());
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
        public void WriteToLog(string planeTagA, string planeTagB, string timeOfOccurrencce)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The two planes {planeTagA} and {planeTagB} had a separation event at {timeOfOccurrencce}");
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
