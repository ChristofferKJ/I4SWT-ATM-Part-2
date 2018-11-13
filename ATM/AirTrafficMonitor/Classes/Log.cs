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

        public void WriteToLog(String PlaneTagA, String PlaneTagB, string TimeOfOccurrencce)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(
                    $"The two planes {PlaneTagA} and {PlaneTagB} had a separation event at {TimeOfOccurrencce}");
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
   
