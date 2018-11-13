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
    [TestFixture]
    class DataReadyEventTest
    {

        private ITransponderReceiver fakeTransponderReceiver;
        private IAirspace fakeAirspace;
        private HandleRTD uut;
        private List<string> testData;
        private List<string> receivedData;
        private int nEventsReceived;

        [SetUp]
        public void SetUp()
        {
            nEventsReceived = 0;
            receivedData = new List<string>();
            testData = new List<string>(); 

            fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            fakeAirspace = Substitute.For<IAirspace>();
            uut = new HandleRTD(fakeTransponderReceiver, fakeAirspace);
            testData.Add("ATR423;39045;12932;14000;20151006123456789");
            
            fakeTransponderReceiver.TransponderDataReady += (o, args) =>
            {
                receivedData = args.TransponderData;
                ++nEventsReceived;
            };
    }

        [Test]
        public void EventIsRaised()
        {
            var args = new RawTransponderDataEventArgs(testData);
            fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(args);
            Assert.That(nEventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void EventRaisedCorrectNumberOfTimes()
        {
            var args = new RawTransponderDataEventArgs(testData);
            fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(args);
            args.TransponderData.Reverse();
            fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(args);
            Assert.That(nEventsReceived,Is.EqualTo(2));
        }

        [Test]
        public void EventRaisedDataAndReceivedCountCompare()
        {
            var args = new RawTransponderDataEventArgs(testData);
            fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(args);
            Assert.That(receivedData.Count,Is.EqualTo(testData.Count));
        }

   
        [Test]
        public void EventRaisedDataAndReceivedElementsCompare()
        {
            int count = 0;
            var args = new RawTransponderDataEventArgs(testData);
            fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(args);
            foreach (string item in receivedData)
            {
                Assert.That(item, Is.EqualTo(testData[count]));
                count++;
            }
            
        }


    }


}
