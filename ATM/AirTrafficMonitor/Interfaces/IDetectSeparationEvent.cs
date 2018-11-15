﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface IDetectSeparationEvent
    public interface IDetectSeparationEvent
    {
        void CheckSepEvent(List<Plane> planes);
      
        void PassSepEvent(Plane plane1, Plane plane2, string timestamp);
    }
}
