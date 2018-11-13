using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class Renedition : IRenedition
    {
        public void render(List<IPlane> planes)
        {
            foreach (IPlane plane in planes)
            {
                Console.WriteLine($"Plane tag: {plane.Tag}");
                Console.WriteLine($"Position: ({plane.XCoordinate},{plane.YCoordinate})");
                Console.WriteLine($"Altitude: {plane.Altitude}m");
                Console.WriteLine($"Speed: {plane.Velocity}m/s");
                Console.WriteLine($"Course: {plane.Course} degrees");
                Console.WriteLine($"Time: {plane.TimeStamp} \n");

            }
            
                
        }
        public void CurSepEvent(string planeA,string planeB, string TimeStamp)
        {
            Console.WriteLine($"The two planes {planeA} and {planeB} had a separation event at {TimeStamp}");
        }

        public void CurEnterEvent(string planeA, string TimeStamp)
        {
            Console.WriteLine($"The plane {planeA} has entered the airspace, at {TimeStamp}");
        }

        public void CurLeavingEvent(string planeA, string TimeStamp)
        {
            Console.WriteLine($"The plane {planeA} has left the airspace, at {TimeStamp}");
        }

    }
}
