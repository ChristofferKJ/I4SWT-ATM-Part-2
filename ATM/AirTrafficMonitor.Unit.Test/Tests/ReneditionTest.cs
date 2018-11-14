using System;
using System.Collections.Generic;
using ATM;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using System.Globalization;
using System.IO;

namespace AirTrafficMonitor.Unit.Test.Tests
{
    
    public class ReneditionTest
    {
        private Renedition uut;
        private IPlane testPlane;
        private IPlane testPlane2;
        private List<IPlane> listOPlanes;

        [SetUp]
        public void SetUp()
        {
            uut = new Renedition();
            testPlane = Substitute.For<IPlane>();
            testPlane2 = Substitute.For<IPlane>();
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

            testPlane2 = new Plane()
            {
                Course = 0,
                Altitude = 15000,
                Tag = "BRW500",
                XCoordinate = 30000,
                YCoordinate = 10000,
                Velocity = 0,
                TimeStamp = DateTime.ParseExact("20181006123456789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture)
            };

            listOPlanes = new List<IPlane>();
            listOPlanes.Add(testPlane);
            listOPlanes.Add(testPlane2);

        }

        [Test]
        public void TestRenderWithListOfPlanes()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                uut.render(listOPlanes);
                //string expected = string.Format($"Plane tag: {testplane.Tag}")
                
            }
                
            
           
        }
    }
}