using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ILog
    {
         void WriteEnteredPlaneToLog(string PlaneTagA, string TimeOfOccurrencce);
         void WriteLeavingPlaneToLog(string PlaneTagA, string TimeOfOccurrencce);
         void ClearLog();
    }
}
