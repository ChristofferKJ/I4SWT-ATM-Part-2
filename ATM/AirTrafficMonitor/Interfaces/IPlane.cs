using System;

namespace ATM
{
    public interface IPlane
    {
        string Tag { get; set; }
         int XCoordinate { get; set; }
         int YCoordinate { get; set; }
         int Altitude { get; set; }
         DateTime TimeStamp { get; set; }
         double Velocity { get; set; }
         double Course { get; set; }
    }
}