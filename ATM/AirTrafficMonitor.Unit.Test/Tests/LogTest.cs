﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitor.Unit.Test.Tests
{
    class LogTest
    {
        private ILog uut;
        private StreamReader sr;
        private IDetectSeparationEvent fakeDetectSeparationEvent;
        private IAirspace fakeAirspace;
        private ICheckPlanes fakeCheckPlanes;
        [SetUp]
        public void Setup()
        {
            fakeDetectSeparationEvent = Substitute.For<IDetectSeparationEvent>();
            fakeAirspace = Substitute.For<IAirspace>();
            fakeCheckPlanes = Substitute.For<ICheckPlanes>();

            uut = new Log(fakeDetectSeparationEvent, fakeAirspace, fakeCheckPlanes);
            uut.ClearLog();
        }


        [TestCase("1234", "1234", "kl.14")]
        [TestCase("abc", "ss", "kl.15")]
        public void TestWriteToLog(string planeTagA, string planeTagB, string timeOfOccurrencce)

        {
            uut.WriteToLog(planeTagA, planeTagB, timeOfOccurrencce);
            using (sr = new StreamReader("Log.txt"))
            {
                string testLogLine = sr.ReadToEnd();
                Assert.IsNotEmpty(testLogLine);
            }

        }

        [TestCase("1234", "kl.14")]
        [TestCase("ss", "kl.15")]
        public void TestWriteLeavingPlaneToLog(string planeTagA, string TimeOfOccurrencce)
        {
            uut.WriteLeavingToLog(planeTagA, TimeOfOccurrencce);
            using (sr = new StreamReader("Log.txt"))
            {
                string testLogLine = sr.ReadToEnd();
                Assert.IsNotEmpty(testLogLine);
            }

        }

        [TestCase("1234", "kl.14")]
        [TestCase("ss", "kl.15")]
        public void TestWriteEnteredPlaneToLog(string planeTagA, string TimeOfOccurrencce)
        {
            uut.WriteEnteredToLog(planeTagA, TimeOfOccurrencce);
            using (sr = new StreamReader("Log.txt"))
            {
                string testLogLine = sr.ReadToEnd();
                Assert.IsNotEmpty(testLogLine);
            }
        }

        [Test]
        public void TestClearLog()
        {
            using (sr=new StreamReader("Log.txt"))
            Assert.IsEmpty(sr.ReadToEnd());
        }


    }
}
