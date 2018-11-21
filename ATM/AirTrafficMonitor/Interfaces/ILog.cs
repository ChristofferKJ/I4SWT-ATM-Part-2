using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ILog
    {
        void WriteToLog(string planeTagA, string planeTagB, string timeOfOccurrencce);
        void WriteSeperationToLog(object sender, SeperationsEventArgs e);
        void WriteEnteredPlaneToLog(object sender, EnterEventArgs e);
        void WriteLeavingPlaneToLog(object sender, LeaveEventArgs e);
        void WriteLeavingToLog(string planeTag, string timeOfOccurrence);
        void WriteEnteredToLog(string planeTag, string timeOfOccurrence);

         void ClearLog();
    }
}
