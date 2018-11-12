using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    public class CheckPlanes
    {
        public List<Plane> Planes { get; set; }

        private CalculateVelocity _cv;
        private CalculateCourse _cc;
        private Renedition _rr; 

        public CheckPlanes(CalculateVelocity cv, CalculateCourse cc, Renedition rr)
        {
            _cc = cc;
            _cv = cv;
            _rr = rr;
            Planes = new List<Plane>();
        }

        public void CheckPlanesInAirspace(List<Plane> newplanes)
        {
            for (int i = 0; i<newplanes.Count; i++)
            {
                for (int k = 0; k < Planes.Count;k++)
                {
                    if(newplanes[k].Tag == Planes[k].Tag)
                    {
                        _cc.CalcCourse(Planes[k], newplanes[k]);
                        _cv.CalcVelocity(Planes[k], newplanes[k]);                    
                    }
                }
            }

            Planes = newplanes;
            _rr.render(Planes);
        }

       
        }

 }

