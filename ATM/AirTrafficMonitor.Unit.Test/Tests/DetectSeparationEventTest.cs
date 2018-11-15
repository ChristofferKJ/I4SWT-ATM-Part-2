using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ATM;
using NSubstitute;


namespace AirTrafficMonitor.Unit.Test.Tests
{
    [TestFixture]
    class DetectSeparationEventTest
    {
        private IDetectSeparationEvent fakeDetectSeparationEvent;
        private IPlane fakePlane1;
        private IPlane fakePlane2;
        private IDetectSeparationEvent uut;
        private string Timestamp;
        private SeperationsEventArgs.Msg receivedData;
        private int nEventsReceived;

        [SetUp]
        public void SetUp()
        {
            nEventsReceived = 0;
            receivedData = new SeperationsEventArgs.Msg();
            Timestamp = "20181006123456789";

            fakeDetectSeparationEvent = Substitute.For<IDetectSeparationEvent>();
            fakePlane1 = Substitute.For<IPlane>();
            fakePlane2 = Substitute.For<IPlane>();

            fakePlane1 = new Plane()
            {
                Course = 0,
                Altitude = 14900,
                Tag = "ATR423",
                XCoordinate = 39045,
                YCoordinate = 12932,
                Velocity = 0,
            };

            fakePlane2 = new Plane()
            {
                Course = 0,
                Altitude = 15000,
                Tag = "BRW500",
                XCoordinate = 39000,
                YCoordinate = 13000,
                Velocity = 0,
            };

            uut = new DetectSeparationEvent();

            fakeDetectSeparationEvent.RaisedSerparationEvent += (o, args) =>
            {
                receivedData = args.Message;
                ++nEventsReceived;
            };
        }

        [Test]
        public void EventIsRaised()
        {
            var args = new SeperationsEventArgs(fakePlane1, fakePlane2, Timestamp);
            fakeDetectSeparationEvent.RaisedSerparationEvent += Raise.EventWith(args);
            Assert.That(nEventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void EventRaisedCorrectNumberOfTimes()
        {
            var args = new SeperationsEventArgs(fakePlane1, fakePlane2, Timestamp);
            fakeDetectSeparationEvent.RaisedSerparationEvent += Raise.EventWith(args);
            fakeDetectSeparationEvent.RaisedSerparationEvent += Raise.EventWith(args);
            Assert.That(nEventsReceived, Is.EqualTo(2));
        }

        [Test]
        public void EventRaisedWrongNumberOfTimes()
        {
            var args = new SeperationsEventArgs(fakePlane1, fakePlane2, Timestamp);
            fakeDetectSeparationEvent.RaisedSerparationEvent += Raise.EventWith(args);
            fakeDetectSeparationEvent.RaisedSerparationEvent += Raise.EventWith(args);
            Assert.That(nEventsReceived, Is.Not.EqualTo(1));
        }


    }
}
