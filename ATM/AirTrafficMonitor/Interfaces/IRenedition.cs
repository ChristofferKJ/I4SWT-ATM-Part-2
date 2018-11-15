using System.Collections.Generic;
using NUnit.Framework;

namespace ATM
{
    public interface IRenedition
    {
        void CurSepEvent(string planeA, string planeB, string TimeStamp);
<<<<<<< HEAD
        void HandleSeparationEvent(object sender, SeperationsEventArgs e);
        void render(List<Plane> planes);
=======
        void render(List<IPlane> planes);
>>>>>>> 2ac673d03d01a670cfd97841419bfd1015d9fdda
    }
}