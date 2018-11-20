using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ATM
{
    public interface IAirspace
    {
        event EventHandler<LeaveEventArgs> RaisedLeaveEvent;
        void CheckAirspace(List<IPlane> airspace); 
    }
}