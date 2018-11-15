using System.Collections.Generic;
using NUnit.Framework;

namespace ATM
{
    public interface IRenedition
    {
        void CurSepEvent(string planeA, string planeB, string TimeStamp);
        void HandleSeparationEvent(object sender, SeperationsEventArgs e);
        void render(List<Plane> planes);
    }
}