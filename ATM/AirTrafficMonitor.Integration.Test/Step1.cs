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
    public class Step1
    {
        private CalculateCourse calccourse;
        private CalculateVelocity calcvelocity;
        private CheckPlanes sut;

        private IRenedition fakerenedition;
        private List<IPlane> fakeplanelist;
        private IPlane fakeplane1;

        [SetUp]
        public void Setup()
        {
            calccourse = new CalculateCourse();
            calcvelocity = new CalculateVelocity();

            fakerenedition = Substitute.For<IRenedition>();
            fakeplanelist = Substitute.For<List<IPlane>>();
            fakeplane1 = Substitute.For<IPlane>();

            sut = new CheckPlanes(calcvelocity, calccourse, fakerenedition);

            fakeplane1 = new Plane();
            fakeplane1.Tag = "ABC123";
            fakeplane1.XCoordinate = 30000;
            fakeplane1.YCoordinate = 30000;
            fakeplane1.Altitude = 17100;

        }

        [Test]
        public void Planes_in_list_is_there()
        {
            fakeplanelist.Add(fakeplane1);
            sut.CheckPlanesInAirspace(fakeplanelist);

            fakerenedition.Received().render(fakeplanelist);
        }
    }
}
