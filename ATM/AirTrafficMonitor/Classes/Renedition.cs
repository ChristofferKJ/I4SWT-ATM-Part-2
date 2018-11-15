﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class Renedition : IRenedition
    {
<<<<<<< HEAD
        public Renedition(DetectSeparationEvent detect)
        {
            Detect = detect;
            Detect.RaisedSerparationEvent += HandleSeparationEvent;
        }
        DetectSeparationEvent Detect;
        
        public void render(List<Plane> planes)
=======
        public void render(List<IPlane> planes)
>>>>>>> 2ac673d03d01a670cfd97841419bfd1015d9fdda
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
        
        public void HandleSeparationEvent(object sender, SeperationsEventArgs e)
        {
            Console.WriteLine($"The two planes {planeA} and {planeB} had a separation event at {TimeStamp}");
            Console.WriteLine($"The two planes {e.Message.plane1.Tag} and {e.Message.plane2.Tag} had a separation event at {e.Message.timestamp}");
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
