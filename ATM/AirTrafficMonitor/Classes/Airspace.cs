using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    public class Airspace
    {
        public List<Plane> Planes { get; set; }
        public const int SouthWest_Y = 10000;
        public const int SouthWest_X = 10000;
        public const int NorthEast_Y = 90000;
        public const int NorthEast_X = 90000;
        public const int MaxHeight = 20000;
        public const int MinHeight = 500;

        private readonly CheckPlanes _cp; 

        public Airspace(CheckPlanes cp)
        {
            _cp = cp;

        }

        public void CheckAirspace(List<Plane> airspace)
        {
            foreach (var plane in airspace.ToList())
            {
                if (plane.XCoordinate < SouthWest_X || plane.YCoordinate < SouthWest_Y || plane.YCoordinate > NorthEast_Y || plane.XCoordinate >NorthEast_X || plane.Altitude < MinHeight || plane.Altitude > MaxHeight)
                {
                    airspace.Remove(plane);
                }
            }

            _cp.CheckPlanesInAirspace(airspace);
        }

    }
}
