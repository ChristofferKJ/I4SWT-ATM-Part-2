using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using NUnit.Framework;
using NSubstitute;

namespace AirTrafficMonitor.Unit.Test.Tests
{
    [TestFixture]
    public class CheckPlanesTest
    {

        private IRenedition fakeRenedition;
        private ICalculateCourse fakeCalculateCourse;
        private ICalculateVelocity fakeCalculateVelocity; 
        private ICheckPlanes uut; 
        private List<IPlane> currentfakePlanes;
        private List<IPlane> newfakePlanes; 
        private IPlane fakePlane1;
        private IPlane fakePlane2;
        private DateTime time1;
        private DateTime time2;

        //SLIK MIG 
        [SetUp]
        public void SetUp()
        {
            newfakePlanes = new List<IPlane>();
            currentfakePlanes = new List<IPlane>();
            time1 = new DateTime(2010, 10, 10, 00, 01, 00);
            time2 = new DateTime(2010, 10, 10, 00, 02, 00);

            fakePlane1 = new Plane();
            fakePlane1.Tag = "ABC123";
            fakePlane1.XCoordinate = 1000;
            fakePlane1.YCoordinate = 1000;
            fakePlane1.Altitude = 17100;
            fakePlane1.TimeStamp = time1;

            fakePlane2 = new Plane();
            fakePlane2.Tag = "ABC123";
            fakePlane2.XCoordinate = 2000;
            fakePlane2.YCoordinate = 2000;
            fakePlane2.Altitude = 18100;
            fakePlane2.TimeStamp = time2;

            currentfakePlanes.Add(fakePlane1);
            fakeCalculateCourse = Substitute.For<ICalculateCourse>();
            fakeCalculateVelocity = Substitute.For<ICalculateVelocity>();
            fakeRenedition = Substitute.For<IRenedition>();
            uut = new CheckPlanes(fakeCalculateVelocity, fakeCalculateCourse, fakeRenedition);
        }


        [Test]
        public void CheckPlanes_TwoPlanesSameTag_CalcVelocityIsCalled()
        {
            uut.CheckPlanesInAirspace(currentfakePlanes);
            newfakePlanes.Add(fakePlane2);
            uut.CheckPlanesInAirspace(newfakePlanes);
            fakeCalculateVelocity.Received().CalcVelocity(currentfakePlanes[0], newfakePlanes[0]);
        }


    }





}
