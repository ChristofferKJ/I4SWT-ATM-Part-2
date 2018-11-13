using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ATM; 
using NSubstitute; 



namespace AirTrafficMonitor.Unit.Test
{
    [TestFixture]
    public class CalculateCourseTest
    {
       
        private IPlane fakePlane1;
        private IPlane fakePlane2;
        private ICalculateCourse uut; 

        [SetUp]
        public void SetUp()
        {
            fakePlane1 = Substitute.For<IPlane>();
            fakePlane2 = Substitute.For<IPlane>();
            uut = new CalculateCourse();

            fakePlane1 = new Plane();
            fakePlane1.Tag = "ABC123";
            fakePlane1.XCoordinate = 5000;
            fakePlane1.YCoordinate = 5000;

            fakePlane2 = new Plane();
            fakePlane2.Tag = "ABC123";
            fakePlane2.XCoordinate = 1000;
            fakePlane2.YCoordinate = 1000;
        }

        [Test]
        public void CC_fly1_fly2_IsNot90deg()
        {
            uut.CalcCourse(fakePlane1, fakePlane2);
            Assert.That(fakePlane1.Course, Is.Not.EqualTo(90));
        }

        [Test]
        public void CC_fly1_fly2_Is()
        {
            uut.CalcCourse(fakePlane1, fakePlane2);
            Assert.That(fakePlane2.Course, Is.EqualTo(45));
        }

        [Test]
        public void CC_fly1_fly2_IsNot()
        {
            uut.CalcCourse(fakePlane1, fakePlane2);
            Assert.That(fakePlane2.Course, Is.Not.EqualTo(95));
        }

        [Test]
        public void CC_fly1_fly2_newcord_IsNot180deg()
        {
            fakePlane1.XCoordinate = 1000;
            fakePlane1.YCoordinate = 1000;
            fakePlane1.XCoordinate = 9000;
            fakePlane1.YCoordinate = 5000;

            uut.CalcCourse(fakePlane1, fakePlane2);
            Assert.That(fakePlane2.Course, Is.Not.EqualTo(180));
        }

        [Test]
        public void CC_fly1_fly2_newcord_Is206p57deg()
        {
            fakePlane1.XCoordinate = 1000;
            fakePlane1.YCoordinate = 1000;
            fakePlane2.XCoordinate = 9000;
            fakePlane2.YCoordinate = 5000;

            uut.CalcCourse(fakePlane1, fakePlane2);
            Assert.That(fakePlane2.Course, Is.EqualTo(206.565051177078));
        }



    }
}
