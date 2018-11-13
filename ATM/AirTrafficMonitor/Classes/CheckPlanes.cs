using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    public class CheckPlanes : ICheckPlanes
    {
        public List<IPlane> Planes { get; set; }

        private ICalculateVelocity _cv;
        private ICalculateCourse _cc;
        private IRenedition _rr; 

        public CheckPlanes(ICalculateVelocity cv, ICalculateCourse cc, IRenedition rr)
        {
            _cc = cc;
            _cv = cv;
            _rr = rr;
            Planes = new List<IPlane>();
        }

        public void CheckPlanesInAirspace(List<IPlane> newplanes)
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

