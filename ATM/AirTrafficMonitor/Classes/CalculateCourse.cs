using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CalculateCourse
    {
       

        public void CalcCourse(Plane oldPlane, Plane newPlane)
        {
            double dx = oldPlane.XCoordinate - newPlane.XCoordinate;
            double dy = oldPlane.YCoordinate - newPlane.YCoordinate;

            double course = Math.Atan2(dy, dx) * (180 / Math.PI);

            if (course < 0)
            {
                course += 360;
            }

            newPlane.Course = course;
            
        }
    }
}
