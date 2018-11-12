using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ATM;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafficMonitor.Unit.Test.Tests
{
    class DataReadyEventTest
    {

        private ITransponderReceiver fakeTransponderReceiver;
        private IAirspace fakeAirspace;
        private HandleRTD uut;
        private List<string> testData = new List<string>();

        [SetUp]
        public void SetUp()
        {
            fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            fakeAirspace = Substitute.For<IAirspace>();
            uut = new HandleRTD(fakeTransponderReceiver, fakeAirspace);

            
            testData.Add("ATR423;");
            testData.Add("39045");
            testData.Add("12932");
            testData.Add("14000");
            testData.Add("20151006123456789");




        }

        [Test]
        public void EventIsRaised()
        {
            var args = new RawTransponderDataEventArgs(testData);
            fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(args);
            // :-(


        }
    }

    
}
