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
        private ICalculateVelocity uut;
        private IPlane fakePlane1;
        private IPlane fakePlane2;

        DateTime time1 = new DateTime(2010, 10, 10, 00, 00, 01, 00);
        DateTime time2 = new DateTime(2010, 10, 10, 00, 00, 02, 00);


        [SetUp]
        public void SetUp()
        {
            uut = new CalculateVelocity();

            fakePlane1 = new Plane();
            fakePlane1.Tag = "ABC123";
            fakePlane1.XCoordinate = 1000;
            fakePlane1.YCoordinate = 1000;
            fakePlane1.Altitude = 17100; 
            fakePlane1.TimeStamp = time1; 

            fakePlane2 = new Plane();
            fakePlane2.Tag = "ABC123";
            fakePlane2.XCoordinate = 2000;
            fakePlane2.YCoordinate = 2000;
            fakePlane2.Altitude = 18100; 
            fakePlane2.TimeStamp = time2; 
        }

        [Test]
        public void CV_fakePlane1_fakePlane2_IsNot900vel()
        {
            uut.CalcVelocity(fakePlane1, fakePlane2);
            Assert.That(fakePlane2.Velocity, Is.Not.EqualTo(900));
        }

        [Test]
        public void CV_fakePlane1_fakePlane2_Is1732p05()
        {
            uut.CalcVelocity(fakePlane1, fakePlane2);
            Assert.That(fakePlane2.Velocity, Is.EqualTo(1732.0508075688772));
        }

        [Test]
        public void CV_fakePlane2_fakePlane1_IsNot1732p05()
        {
            uut.CalcVelocity(fakePlane2, fakePlane1);
            Assert.That(fakePlane2.Velocity, Is.Not.EqualTo(1732.0508075688772));
        }

        [Test]
        public void CV_fakePlane1_fakePlane2_newTime_Is28p87()
        {
            fakePlane1.TimeStamp = new DateTime(2010, 10, 10, 00, 00, 00, 00);
            fakePlane2.TimeStamp = new DateTime(2010, 10, 10, 00, 01, 00, 00);

            uut.CalcVelocity(fakePlane1, fakePlane2);
            Assert.That(fakePlane2.Velocity, Is.EqualTo(28.867513459481287));

        }

        [Test]
        public void CV_fakePlane1_fakePlane2_newTime_IsNot28p87()
        {
            fakePlane1.TimeStamp = new DateTime(2010, 10, 01, 00, 00, 00, 00);
            fakePlane2.TimeStamp = new DateTime(2010, 10, 10, 00, 01, 00, 00);

            uut.CalcVelocity(fakePlane1, fakePlane2);
            Assert.That(fakePlane2.Velocity, Is.Not.EqualTo(28.867513459481287));

        }





    }
}
