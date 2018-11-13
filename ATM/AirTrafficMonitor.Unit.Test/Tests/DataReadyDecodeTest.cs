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
    class DataReadyDecodeTest
    {
        private ITransponderReceiver fakeTransponderReceiver;
        private HandleRTD uut;
        private IAirspace fakeAirspace;
        private Plane testPlane;

        private string testPlaneString;
        
        [SetUp]
        public void SetUp()
        {
            fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            fakeAirspace = Substitute.For<IAirspace>();
            uut = new HandleRTD(fakeTransponderReceiver, fakeAirspace);
            testPlaneString = "ATR423;39045;12932;14000;20151006123456789";
            testPlane = new Plane()
            {
                Course = 0,
                Altitude = 14000,
                Tag = "ATR423",
                XCoordinate = 39045,
                YCoordinate = 12932,
                Velocity = 0,
                TimeStamp = DateTime.ParseExact("20151006123456789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture)
            };
        }

        [Test]
        public void TestDecodeDataTag()
        {
            Plane testStringPlane = uut.Decode(testPlaneString);
            Assert.AreEqual(testStringPlane.Tag, testPlane.Tag);
        }

        [Test]
        public void TestDecodeDataTimeStamp()
        {
            Plane testStringPlane = uut.Decode(testPlaneString);
            Assert.AreEqual(testStringPlane.Course, testPlane.Course);
        }

        [Test]
        public void TestDecodeDataCourse()
        {
            Plane testStringPlane = uut.Decode(testPlaneString);
            Assert.AreEqual(testStringPlane.Course, testPlane.Course);
        }

        [Test]
        public void TestDecodeDataAltitude()
        {

            Plane testStringPlane = uut.Decode(testPlaneString);
            Assert.AreEqual(testStringPlane.Altitude, testPlane.Altitude);
        }

        [Test]
        public void TestDecodeDataXCoordinate()
        {
            Plane testStringPlane = uut.Decode(testPlaneString);
            Assert.AreEqual(testStringPlane.XCoordinate, testPlane.XCoordinate);
        }

        [Test]
        public void TestDecodeDataYCoordinate()
        {
            Plane testStringPlane = uut.Decode(testPlaneString);
            Assert.AreEqual(testStringPlane.YCoordinate, testPlane.YCoordinate);
        }

        [Test]
        public void TestDecodeDataVelcocity()
        {
            Plane testStringPlane = uut.Decode(testPlaneString);
            Assert.AreEqual(testStringPlane.Velocity, testPlane.Velocity);
        }





    }
}

