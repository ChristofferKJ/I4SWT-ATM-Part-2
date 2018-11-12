using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafficMonitor.Unit.Test.Tests
{
    class HandleRTDTest
    {
        private ITransponderReceiver fakeTransponderReceiver;
        private HandleRTD uut;
        private Airspace airspace;
        private CheckPlanes checkPlanes;
        private CalculateCourse calculateCourse;
        private CalculateVelocity calculateVelocity;
        private Renedition renedition;

        [SetUp]
        public void SetUp()
        {
            fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            calculateCourse = new CalculateCourse();
            calculateVelocity = new CalculateVelocity();
            renedition = new Renedition();
            checkPlanes = new CheckPlanes(calculateVelocity, calculateCourse, renedition);
            airspace = new Airspace(checkPlanes);
            uut = new HandleRTD(fakeTransponderReceiver, airspace);
        }

        [Test]
        public void TestDecode()
        {
            string testPlaneString = "ATR423;39045;12932;14000;20151006123456789";

            Plane testPlane = new Plane()
            {
                Course = 0,
                Altitude = 14000,
                Tag = "ATR423",
                XCoordinate = 39045,
                YCoordinate = 12932,
                Velocity = 0,
                TimeStamp = DateTime.ParseExact("20151006123456789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture)
            };

            Plane testStringPlane = uut.Decode(testPlaneString);

            Assert.AreEqual(testStringPlane.Tag, testPlane.Tag);
            Assert.AreEqual(testStringPlane.TimeStamp, testPlane.TimeStamp);
            Assert.AreEqual(testStringPlane.Course, testPlane.Course);
            Assert.AreEqual(testStringPlane.Altitude, testPlane.Altitude);
            Assert.AreEqual(testStringPlane.YCoordinate, testPlane.YCoordinate);
            Assert.AreEqual(testStringPlane.XCoordinate, testPlane.XCoordinate);
            Assert.AreEqual(testStringPlane.Velocity, testPlane.Velocity);
        }


        [Test]
        public void TestEvent() // Desværre ikke færdig :(
        {
            
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");

            Plane testPlane = new Plane()
            {
                Course = 0,
                Altitude = 14000,
                Tag = "ATR423",
                XCoordinate = 39045,
                YCoordinate = 12932,
                Velocity = 0,
                TimeStamp = DateTime.ParseExact("20151006123456789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture)
            };


            fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(this,new RawTransponderDataEventArgs(testData));
            
            // Mangler assert et eller andet 
        }

       

    }
}
