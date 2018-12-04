using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ATM;
using NSubstitute;

namespace AirTrafficMonitor.Integration.Test
{
    [TestFixture]
    public class Step2
    {
        private CalculateCourse calccourse;
        private CalculateVelocity calcvelocity;
        private CheckPlanes sut;

        private IRenedition fakerenedition;
        private List<IPlane> fakeplanelist;
        private IPlane fakeplane1;
        private IPlane fakeplane2;

        [SetUp]
        public void Setup()
        {
            calccourse = new CalculateCourse();
            calcvelocity = new CalculateVelocity();

            fakerenedition = Substitute.For<IRenedition>();
            fakeplanelist = Substitute.For<List<IPlane>>();
            fakeplane1 = Substitute.For<IPlane>();
            fakeplane2 = Substitute.For<IPlane>();

            sut = new CheckPlanes(calcvelocity, calccourse, fakerenedition);

            fakeplane1 = new Plane();
            fakeplane1.Tag = "ABC123";
            fakeplane1.XCoordinate = 30000;
            fakeplane1.YCoordinate = 30000;
            fakeplane1.Altitude = 17100;

            fakeplane2 = new Plane();
            fakeplane2.Tag = "ABC123";
            fakeplane2.XCoordinate = 40000;
            fakeplane2.YCoordinate = 35000;
            fakeplane2.Altitude = 17100;

        }

        [Test]
        public void Plane_in_list_is_there()
        {
            fakeplanelist.Add(fakeplane1);
            sut.CheckPlanesInAirspace(fakeplanelist);
            Assert.That(fakeplanelist[0].Tag, Is.EqualTo(fakeplane1.Tag));
        }

        [Test]
        public void Check_CalcCourse_Works_Correctly()
        {
            fakeplanelist.Add(fakeplane1);
            sut.CheckPlanesInAirspace(fakeplanelist);

            fakeplanelist.Add(fakeplane2);
            sut.CheckPlanesInAirspace(fakeplanelist);

            double planex = fakeplane1.XCoordinate - fakeplane2.XCoordinate;
            double planey = fakeplane1.YCoordinate - fakeplane2.YCoordinate;

            double expected = Math.Atan2(planey, planex) * (180 / Math.PI);
            if (expected < 0)
            {
                expected += 360;
            }

            Assert.AreEqual(expected, fakeplanelist[1].Course);
        }

        [Test]
        public void Check_CalcVelocity_Works_Correctly()
        {
            fakeplanelist.Add(fakeplane1);
            sut.CheckPlanesInAirspace(fakeplanelist);

            fakeplanelist.Add(fakeplane2);
            sut.CheckPlanesInAirspace(fakeplanelist);

            double XYDiff = Math.Sqrt((Math.Pow((fakeplane2.XCoordinate - fakeplane1.XCoordinate), 2) + Math.Pow((fakeplane2.YCoordinate - fakeplane1.YCoordinate), 2)));
            double AltitudeDiff = Math.Abs(fakeplane1.Altitude - fakeplane2.Altitude);
            double DistanceMoved = Math.Sqrt((Math.Pow(XYDiff, 2) + Math.Pow(AltitudeDiff, 2)));
            double TimeUsed = fakeplane2.TimeStamp.Subtract(fakeplane1.TimeStamp).TotalSeconds;
            double expected = (DistanceMoved / TimeUsed);

            Assert.AreEqual(expected, fakeplanelist[1].Velocity);
        }
    }
}
