using System;
using System.Collections.Generic;
using System.ComponentModel;
using ATM;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using System.Globalization;
using System.IO;
using System.Security.AccessControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;


namespace AirTrafficMonitor.Unit.Test.Tests
{
    
    public class ReneditionTest
    {
        private Renedition uut;
        private IPlane testPlane;
        private IPlane testPlane2;
        private List<IPlane> listOPlanes;
        private IDetectSeparationEvent fakeDetectSeparationEvent;
        private ICheckPlanes fakeCheckPlanes;
        private IAirspace fakeAirspace;
        private EnterEventArgs.Msg receivedData;
        private LeaveEventArgs.Msg receivedData2;
        private int nEventsReceived;

        [SetUp]
        public void SetUp()
        {
            fakeDetectSeparationEvent = Substitute.For<IDetectSeparationEvent>();
            uut = new Renedition();
            testPlane = Substitute.For<IPlane>();
            testPlane2 = Substitute.For<IPlane>();
            fakeCheckPlanes = Substitute.For<ICheckPlanes>();
            fakeAirspace = Substitute.For<IAirspace>();
            nEventsReceived = 0;
            receivedData = new EnterEventArgs.Msg();
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

            fakeCheckPlanes.RaisedEnterEvent += (o, args) =>
            {
                receivedData = args.Message;
                ++nEventsReceived;
            };

            fakeAirspace.RaisedLeaveEvent += (o, args) =>
            {
                receivedData2 = args.Message;
                ++nEventsReceived;
            };

        }

        [TestInitialize]
        public void InitializeTest()
        {
            StreamWriter standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        [Test]
        public void TestRenderWithOneTestPlanes()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                uut.render(listOPlanes); // List has one plane

                string expected = string.Format($"Plane tag: {testPlane.Tag}{Environment.NewLine}");
                expected += string.Format($"Position: ({testPlane.XCoordinate},{testPlane.YCoordinate}){Environment.NewLine}");
                expected += string.Format($"Altitude: {testPlane.Altitude}m{Environment.NewLine}");
                expected += string.Format($"Speed: {testPlane.Velocity}m/s{Environment.NewLine}");
                expected += string.Format($"Course: {testPlane.Course} degrees{Environment.NewLine}");
                expected += string.Format($"Time: {testPlane.TimeStamp} \n{Environment.NewLine}");
                Assert.AreEqual(expected,sw.ToString());

            }
                
        }

        [Test]
        public void TestRenderWithListOfTestPlanes()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                listOPlanes.Add(testPlane2);
                uut.render(listOPlanes); // Adding plane to list. Now contains two planes :-) 
                string expected = "";

                foreach (var testPlane in listOPlanes)
                {
                    expected += string.Format($"Plane tag: {testPlane.Tag}{Environment.NewLine}");
                    expected += string.Format($"Position: ({testPlane.XCoordinate},{testPlane.YCoordinate}){Environment.NewLine}");
                    expected += string.Format($"Altitude: {testPlane.Altitude}m{Environment.NewLine}");
                    expected += string.Format($"Speed: {testPlane.Velocity}m/s{Environment.NewLine}");
                    expected += string.Format($"Course: {testPlane.Course} degrees{Environment.NewLine}");
                    expected += string.Format($"Time: {testPlane.TimeStamp} \n{Environment.NewLine}");
                }
              
                Assert.AreEqual(expected, sw.ToString());

            }

        }

        [Test]
        public void TestHandleEnterEvent()
        {
            var args = new EnterEventArgs(testPlane, "20181006123456789");
            fakeCheckPlanes.RaisedEnterEvent += Raise.EventWith(args);
            Assert.That(nEventsReceived, Is.EqualTo(1));
            Assert.AreEqual(receivedData.plane1, args.Message.plane1);
        }

        [Test]
        public void TestHandleLeaveEvent()
        {
            var args = new LeaveEventArgs(testPlane, "20181006123456789");
            fakeAirspace.RaisedLeaveEvent += Raise.EventWith(args);
            Assert.That(nEventsReceived, Is.EqualTo(1));
            Assert.AreEqual(receivedData2.plane1, args.Message.plane1);
        }

        [Test]
        public void TestHandleLeaveEventPrint()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string expected = "";
                var args = new LeaveEventArgs(testPlane, "20181006123456789");
                uut.HandleLeaveEvent(fakeAirspace, args);
                fakeAirspace.RaisedLeaveEvent += Raise.EventWith(args);
                expected += string.Format($"The plane {args.Message.plane1.Tag} has left the airspace, at {args.Message.plane1.TimeStamp}{Environment.NewLine}");
                Assert.AreEqual(sw.ToString(), expected);
            }
        }

        [Test]
        public void TestHandleEnterEventPrint()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string expected = "";
                var args = new EnterEventArgs(testPlane, "20181006123456789");
                uut.HandelEnterEvent(fakeCheckPlanes, args);
                fakeCheckPlanes.RaisedEnterEvent += Raise.EventWith(args);
                expected += string.Format($"The plane {args.Message.plane1.Tag} has entered the airspace, at {args.Message.timestamp}{ Environment.NewLine}");
                Assert.AreEqual(sw.ToString(), expected);
            }
        }



    }
}