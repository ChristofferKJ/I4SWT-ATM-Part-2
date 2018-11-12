using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ATM; 



namespace AirTrafficMonitor.Unit.Test
{
    [TestFixture]
    public class CalculateVelocityTest
    {
        private CalculateVelocity uut;
        private Plane fly1;
        private Plane fly2;

        DateTime time1 = new DateTime(2010, 10, 10, 00, 00, 01, 00);
        DateTime time2 = new DateTime(2010, 10, 10, 00, 00, 02, 00);


        [SetUp]
        public void SetUp()
        {
            uut = new CalculateVelocity();

            fly1 = new Plane();
            fly1.Tag = "ABC123";
            fly1.XCoordinate = 1000;
            fly1.YCoordinate = 1000;
            fly1.Altitude = 17100; 
            fly1.TimeStamp = time1; 

            fly2 = new Plane();
            fly2.Tag = "ABC123";
            fly2.XCoordinate = 2000;
            fly2.YCoordinate = 2000;
            fly2.Altitude = 18100; 
            fly2.TimeStamp = time2; 
        }

        [Test]
        public void CV_fly1_fly2_IsNot900vel()
        {
            uut.CalcVelocity(fly1, fly2);
            Assert.That(fly2.Velocity, Is.Not.EqualTo(900));
        }

        [Test]
        public void CV_fly1_fly2_Is1732p05()
        {
            uut.CalcVelocity(fly1, fly2);
            Assert.That(fly2.Velocity, Is.EqualTo(1732.0508075688772));
        }

        [Test]
        public void CV_fly1_fly2_newTime_Is28p87()
        {
            fly1.TimeStamp = new DateTime(2010, 10, 10, 00, 00, 00, 00);
            fly2.TimeStamp = new DateTime(2010, 10, 10, 00, 01, 00, 00);

            uut.CalcVelocity(fly1, fly2);
            Assert.That(fly2.Velocity, Is.EqualTo(28.867513459481287));

        }
    }
}
