using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    public class CheckPlanes : ICheckPlanes
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
                    if(newplanes[i].Tag == Planes[k].Tag)
                    {
                        _cc.CalcCourse(Planes[k], newplanes[i]);
                        _cv.CalcVelocity(Planes[k], newplanes[i]);                    
                    }
                }
            }

            Planes = newplanes;
            _rr.render(Planes);
        }

       
        }

 }

