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
    public class CalculateCourseTest
    {
        private CalculateCourse uut;
        private Plane fly1;
        private Plane fly2;

        [SetUp]
        public void SetUp()
        {
            uut = new CalculateCourse();

            fly1 = new Plane();
            fly1.Tag = "ABC123";
            fly1.XCoordinate = 5000;
            fly1.YCoordinate = 5000;

            fly2 = new Plane();
            fly2.Tag = "ABC123";
            fly2.XCoordinate = 1000;
            fly2.YCoordinate = 1000;
        }

        [Test]
        public void CC_fly1_fly2_IsNot90deg()
        {
            uut.CalcCourse(fly1, fly2);
            Assert.That(fly2.Course, Is.Not.EqualTo(90));
        }

        [Test]
        public void CC_fly1_fly2_Is()
        {
            uut.CalcCourse(fly1, fly2);
            Assert.That(fly2.Course, Is.EqualTo(45));
        }

        [Test]
        public void CC_fly1_fly2_newcord_IsNot180deg()
        {
            fly1.XCoordinate = 1000;
            fly1.YCoordinate = 1000;
            fly2.XCoordinate = 9000;
            fly2.YCoordinate = 5000;

            uut.CalcCourse(fly1, fly2);
            Assert.That(fly2.Course, Is.Not.EqualTo(180));
        }

        [Test]
        public void CC_fly1_fly2_newcord_Is206p57deg()
        {
            fly1.XCoordinate = 1000;
            fly1.YCoordinate = 1000;
            fly2.XCoordinate = 9000;
            fly2.YCoordinate = 5000;

            uut.CalcCourse(fly1, fly2);
            Assert.That(fly2.Course, Is.EqualTo(206.565051177078));
        }
    }
}
