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
         void WriteEnteredPlaneToLog(string PlaneTagA, string TimeOfOccurrencce);
         void WriteLeavingPlaneToLog(string PlaneTagA, string TimeOfOccurrencce);
         void ClearLog();
    }
}
