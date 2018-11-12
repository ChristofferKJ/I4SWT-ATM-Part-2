using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CalculateVelocity
    {
        public void CalcVelocity(Plane oldPlane, Plane newPlane)
        {
            double XYDiff = Math.Sqrt((Math.Pow((newPlane.XCoordinate - oldPlane.XCoordinate),2) + Math.Pow((newPlane.YCoordinate - oldPlane.YCoordinate),2)));
            double AltitudeDiff = Math.Abs(oldPlane.Altitude - newPlane.Altitude);
            double DistanceMoved = Math.Sqrt((Math.Pow(XYDiff,2) + Math.Pow(AltitudeDiff,2)));
            double TimeUsed = newPlane.TimeStamp.Subtract(oldPlane.TimeStamp).TotalSeconds;
            newPlane.Velocity = (DistanceMoved / TimeUsed);
        }

    }
}
