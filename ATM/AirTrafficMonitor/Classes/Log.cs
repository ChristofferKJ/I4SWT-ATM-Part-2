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
        public Log(DetectSeparationEvent detect)
        {
            IDetectSeparationEvent Detect;
            Detect = detect;
            Detect.RaisedSerparationEvent += HandleSeparationEvent;
        }
        public void HandleSeparationEvent(object sender, SeperationsEventArgs e)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The two planes {e.Message.plane1.Tag} and {e.Message.plane2.Tag} had a separation event at {e.Message.plane1.TimeStamp}");
            }

        }

        public void WriteEnteredPlaneToLog(string PlaneTagA, string TimeOfOccurrencce)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The plane {PlaneTagA} has entered the airspace, at {TimeOfOccurrencce}");
            }
        }

        public void WriteLeavingPlaneToLog(string PlaneTagA, string TimeOfOccurrencce)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The plane {PlaneTagA} has left the airspace, at {TimeOfOccurrencce}");
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
   
