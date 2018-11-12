using System.Collections.Generic;
using NUnit.Framework;

namespace ATM
{
    public interface IAirspace
    {
        void CheckAirspace(List<Plane> airspace); 
    }
}