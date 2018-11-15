using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IDetectSeparationEvent
    {
        event EventHandler<SeperationsEventArgs> RaisedSerparationEvent;
        void CheckSepEvent(List<IPlane> planes);
      
        void PassSepEvent(Plane plane1, Plane plane2, string timestamp);

    }
}
