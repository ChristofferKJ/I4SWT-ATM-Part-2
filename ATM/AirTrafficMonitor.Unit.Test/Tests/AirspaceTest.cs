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

        private ILeaveEvent fakeILeaveEvent;
        private int nEventsReceived;
        private LeaveEventArgs.Msg receivedData;
        private DateTime time1; 
        



        [SetUp]
        public void SetUp()
        {
            fakeCheckPlanes = Substitute.For<ICheckPlanes>();
            uut = new Airspace(fakeCheckPlanes);
            fakePlanes = new List<IPlane>();
            fakeILeaveEvent = Substitute.For<ILeaveEvent>();
            receivedData = new LeaveEventArgs.Msg();
            nEventsReceived = 0;

            CheckPlanes.ListOfTags = new List<string>();  
            time1 = new DateTime(2010, 10, 10, 00, 01, 00);

            fakePlane = new Plane();
            fakePlane.XCoordinate = 20000;
            fakePlane.YCoordinate = 42000;
            fakePlane.Altitude = 900;
            fakePlane.Tag = "MarkusFriis"; 
            fakePlanes.Add(fakePlane);
            

            fakeILeaveEvent.RaisedLeaveEvent += (o, args) =>
            {
                receivedData = args.Message;
                ++nEventsReceived;
            };

            
        }

    [Test]
        public void Airspace_PlaneIsInAirspace()
        {
          
            uut.CheckAirspace(fakePlanes);
            Assert.That(fakePlanes.Count, Is.EqualTo(1));
        }


        [Test]
        public void Airspace_PlaneDeletedAltitudeTooLow()
        {
            uut.CheckAirspace(fakePlanes);
            fakePlanes[0].Altitude = 499;
            uut.CheckAirspace(fakePlanes);
            Assert.That(CheckPlanes.ListOfTags, Is.Empty);
        }

        [Test]
        public void CompareElementIsEqualOfRaisedEventArgsTest()
        {
            var args = new LeaveEventArgs(fakePlane, time1.ToString());
            fakeILeaveEvent.RaisedLeaveEvent += Raise.EventWith(args);
            Assert.That(receivedData.plane1.Tag, Is.EqualTo(args.Message.plane1.Tag));

        }

        [Test]
        public void CompareElementIsNotEqualOfRaisedEventArgsTest()
        {
            var args = new LeaveEventArgs(fakePlane, time1.ToString());
            fakeILeaveEvent.RaisedLeaveEvent += Raise.EventWith(args);
            Assert.That(fakePlane, Is.Not.EqualTo(args.Message.plane1.Tag));

        }



    }
}
