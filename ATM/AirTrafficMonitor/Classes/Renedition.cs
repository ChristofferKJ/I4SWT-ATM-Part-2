using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class Renedition : IRenedition
    {
        public Renedition()
        { }
        public Renedition(IDetectSeparationEvent detectSep, ICheckPlanes detectEnter, IAirspace detectLeave)
        {
            DetectSep = detectSep;
            DetectSep.RaisedSerparationEvent += HandleSeparationEvent;
            DetectEnter = detectEnter;
            DetectEnter.RaisedEnterEvent += HandelEnterEvent;
            DetectLeave = detectLeave;
            DetectLeave.RaisedLeaveEvent += HandleLeaveEvent;
        }
        IDetectSeparationEvent DetectSep;
        ICheckPlanes DetectEnter;
        IAirspace DetectLeave;

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
        
        public void HandleSeparationEvent(object sender, SeperationsEventArgs e)
        {
            Console.WriteLine($"The two planes {e.Message.plane1.Tag} and {e.Message.plane2.Tag} had a separation event at {e.Message.timestamp}");
        }

        public void HandelEnterEvent(object sender, EnterEventArgs e)
        {
            Console.WriteLine($"The plane {e.Message.plane1.Tag} has entered the airspace, at {e.Message.timestamp}");
        }

        public void HandleLeaveEvent(object sender, LeaveEventArgs e) 
        {
            Console.WriteLine($"The plane {e.Message.plane1.Tag} has left the airspace, at {e.Message.plane1.TimeStamp}");
        }

    }
}
