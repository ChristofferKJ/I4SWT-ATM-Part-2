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

        private string testPlaneString = "ATR423;39045;12932;14000;20151006123456789";
        
        [SetUp]
        public void SetUp()
        {
            fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            fakeAirspace = Substitute.For<IAirspace>();
            uut = new HandleRTD(fakeTransponderReceiver, fakeAirspace);
        }

        [Test]
        public void TestDecodeData()
        {
            
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



    }
}

