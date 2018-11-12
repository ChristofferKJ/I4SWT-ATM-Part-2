using System.Collections.Generic;
using NUnit.Framework;

namespace ATM
{
    public interface ICheckPlanes
    {
        void CheckPlanesInAirspace(List<Plane> newplanes); 

    }
}