using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitor.Unit.Test.Tests
{
    [TestFixture]
    public class AirspaceTest
    {
        private IAirspace uut;
        private IPlane fakePlane;
        private List<IPlane> fakePlanes;
        private ICheckPlanes fakeCheckPlanes;

        [SetUp]
        public void SetUp()
        {
            fakeCheckPlanes = Substitute.For<ICheckPlanes>();
            uut = new Airspace(fakeCheckPlanes);
            fakePlanes = new List<IPlane>();
        }

        [Test]
        public void Airspace_PlaneIsInAirspace()
        {
            fakePlane = new Plane();
            fakePlane.XCoordinate = 80000;
            fakePlane.YCoordinate = 80000;
            fakePlane.Altitude = 20000;
            fakePlanes.Add(fakePlane); 
            uut.CheckAirspace(fakePlanes);

            Assert.That(fakePlanes.Count, Is.EqualTo(1));
        }


        [Test]
        public void Airspace_PlaneDeletedAltitudeTooLow()
        {
            fakePlane = new Plane();
            fakePlane.XCoordinate = 20000;
            fakePlane.YCoordinate = 50;
            fakePlane.Altitude = 90;
            fakePlanes.Add(fakePlane);
            uut.CheckAirspace(fakePlanes);

            Assert.That(fakePlanes.Count, Is.EqualTo(0));
        }

    }
}
