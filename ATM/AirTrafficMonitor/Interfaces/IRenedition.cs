using System.Collections.Generic;
using NUnit.Framework;

namespace ATM
{
    public interface IRenedition
    {
        void CurSepEvent(string planeA, string planeB, string TimeStamp);
        void render(List<IPlane> planes);
    }
}