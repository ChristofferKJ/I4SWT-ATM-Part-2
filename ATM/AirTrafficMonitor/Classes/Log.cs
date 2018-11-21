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
        public Log(IDetectSeparationEvent detect)
        {
            IDetectSeparationEvent Detect;
            Detect = detect;
            Detect.RaisedSerparationEvent += HandleSeparationEvent;
        }
        public void HandleSeparationEvent(object sender, SeperationsEventArgs e)
        {
            WriteToLog(e.Message.plane1.Tag, e.Message.plane2.Tag, e.Message.timestamp.ToString());
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
   
