using System;
using System.Collections.Generic;
using System.IO;
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
        private IEnterEvent fakeEnterEvent;
        private EnterEventArgs.Msg receivedData; 
        private int nEventsReceived;
        private IEnterEvent fakeIEnterEvent;
        private List<string> fakeListOfTags; 

        [SetUp]
        public void SetUp()
        {
            receivedData = new EnterEventArgs.Msg();
            

            nEventsReceived = 0; 
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

            


            currentfakePlanes.Add(fakePlane1);
            fakeCalculateCourse = Substitute.For<ICalculateCourse>();
            fakeCalculateVelocity = Substitute.For<ICalculateVelocity>();
            fakeRenedition = Substitute.For<IRenedition>();
            fakeIEnterEvent = Substitute.For<IEnterEvent>();
            uut = new CheckPlanes(fakeCalculateVelocity, fakeCalculateCourse, fakeRenedition);

            fakeListOfTags = CheckPlanes.ListOfTags;


            fakeIEnterEvent.RaisedEnterEvent += (o, args) =>
            {
                receivedData = args.Message;
                ++nEventsReceived;
            };

      
        }

        [Test]
        public void EventIsRaised()
        {
            var args = new EnterEventArgs(fakePlane1, time1.ToString());
            fakeIEnterEvent.RaisedEnterEvent += Raise.EventWith(args);
            Assert.That(nEventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void CompareElementIsEqualOfRaisedEventArgsTest()
        {
            var args = new EnterEventArgs(fakePlane1, time1.ToString());
            fakeIEnterEvent.RaisedEnterEvent += Raise.EventWith(args);
            Assert.That(receivedData.plane1.Tag, Is.EqualTo(args.Message.plane1.Tag));
            
        }

         [Test]
        public void CompareElementIsNotEqualOfRaisedEventArgsTest()
        {
            var args = new EnterEventArgs(fakePlane1, time1.ToString());
            fakeIEnterEvent.RaisedEnterEvent += Raise.EventWith(args);
            Assert.That(fakePlane2, Is.Not.EqualTo(args.Message.plane1.Tag));
            
        }

        [Test]
        public void CheckPlanes_PlaneSameTag()
        {
            List<IPlane> testList = new List<IPlane>();
            testList.Add(fakePlane1);
            uut.CheckPlanesInAirspace(testList);
            Assert.That(fakeListOfTags[0], Is.EqualTo(fakePlane1.Tag));
        }



    }
}
