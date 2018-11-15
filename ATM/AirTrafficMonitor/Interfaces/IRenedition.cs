using System.Collections.Generic;
using NUnit.Framework;

namespace ATM
{
    public interface IRenedition
    {
 
        void HandleSeparationEvent(object sender, SeperationsEventArgs e);
        void render(List<IPlane> planes);

    }
}