using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ATM
{
    public interface ICheckPlanes
    {
        event EventHandler<EnterEventArgs>RaisedEnterEvent;
        void CheckPlanesInAirspace(List<IPlane> newplanes); 

    }
}