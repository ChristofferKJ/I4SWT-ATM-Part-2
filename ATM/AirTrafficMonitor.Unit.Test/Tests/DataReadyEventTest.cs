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
        private List<string> testData = new List<string>();
        private List<string> receivedData = new List<string>();

        private int nEventsReceived;

        [SetUp]
        public void SetUp()
        {
            fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            fakeAirspace = Substitute.For<IAirspace>();
            uut = new HandleRTD(fakeTransponderReceiver, fakeAirspace);
            fakeTransponderReceiver.TransponderDataReady += (o, args) =>
            {
                receivedData = args.TransponderData;
                ++nEventsReceived;
            };
            
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
        public void EventRaisedDataAndReceivedCountDoesntCompare()
        {
            testData.Add("TestElement");
            var args = new RawTransponderDataEventArgs(testData);
            fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(args);
            Assert.That(receivedData.Count, Is.Not.EqualTo(testData.Count));
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
