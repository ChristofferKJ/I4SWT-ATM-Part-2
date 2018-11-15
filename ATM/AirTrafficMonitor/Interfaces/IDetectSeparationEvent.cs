using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface IDetectSeparationEvent
    public interface IDetectSeparationEvent
    {
<<<<<<< HEAD
        void CheckSepEvent(List<Plane> planes);
      
        void PassSepEvent(Plane plane1, Plane plane2, string timestamp);
=======
        void CheckSepEvent(List<IPlane> planes);
>>>>>>> 2ac673d03d01a670cfd97841419bfd1015d9fdda
    }
}
