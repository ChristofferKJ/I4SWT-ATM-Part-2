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
        [SetUp]
        public void Setup()
        {
            uut = new Log();
            uut.ClearLog();
        }


        [TestCase("1234", "1234", "kl.14")]
        [TestCase("abc", "ss", "kl.15")]
        [TestCase("", "", "")]
        public void TestWriteToLog(string planeTagA, string planeTagB, string timeOfOccurrencce)

        {
            uut.WriteToLog(planeTagA, planeTagB, timeOfOccurrencce);
            using (sr = new StreamReader("Log.txt"))
            {
                string testLogLine = sr.ReadToEnd();
                Assert.IsNotEmpty(testLogLine);
            }

        }

    }
}
