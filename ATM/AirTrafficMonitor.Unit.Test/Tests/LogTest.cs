using System;
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
        private ILog fakeLog;
       
        [SetUp]
        public void Setup()
        {
            fakeLog = Substitute.For<ILog>();
        }


       /* [TestCase("1234","1234","kl.14")]
        [TestCase("abc", "ss", "kl.15")]
        [TestCase("", "", "")]
        public void TestWriteToLog(string planeTagA, string planeTagB, string timeOfOccurrencce) 
        // Vi kom desværre ikke i mål med denne test. Den virkede lokalt, men der var problemer da det kørte på Jenkins.
        {
            fakeLog.WriteToLog(planeTagA, planeTagB, timeOfOccurrencce);
            using (StreamReader sr = new StreamReader("Log.txt"))
            {
                string testLogLine = sr.ReadToEnd();
                //Assert.IsNotEmpty(testLogLine);
            }
            
        }
        */

    }
}
