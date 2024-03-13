using System;
using NUnit.Framework;
using Clock; // Make sure this namespace matches the one in the ClockClass file

namespace Clock.Tests
{
    [TestFixture]
    public class ClockClassTests
    {
        private Clock _clock;

        [SetUp]
        public void SetUp()
        {
            _clock = new Clock();
        }

        [Test]
        public void TestClockStartsAtZero()
        {
            // Perform assertions to test that the clock starts at 00:00:00
            Assert.AreEqual("00:00:00", _clock.PrintTIme()); // Assuming you add a GetTime() method to ClockClass
        }

        [Test]
        public void TestClockIncrementsTime()
        {
            // Perform assertions to test that the clock increments time properly
            _clock.GetTime(); // Advance the clock
            Assert.AreEqual("00:00:01", _clock.PrintTIme());
        }

        [Test]
        public void TestClockIncrementsMinutes()
        {
            _clock.GetTime(); // Advance the clock by 1 second
            Assert.AreEqual("00:00:01", _clock.PrintTIme());

            // Advance the clock by 59 seconds to reach 00:01:00
            for (int i = 0; i < 59; i++)
            {
                _clock.GetTime();
            }
            Assert.AreEqual("00:01:00", _clock.PrintTIme());
        }

        [Test]
        public void TestClockIncrementsHours()
        {
            // Advance the clock by 59 minutes and 59 seconds to reach 00:59:59
            for (int i = 0; i < 59 * 60 + 59; i++)
            {
                _clock.GetTime();
            }
            Assert.AreEqual("00:59:59", _clock.PrintTIme());

            // Advance the clock by 1 more second to reach 01:00:00
            _clock.GetTime();
            Assert.AreEqual("01:00:00", _clock.PrintTIme());

            // Advance the clock by 59 minutes and 59 seconds to reach 01:59:59
            for (int i = 0; i < 59 * 60 + 59; i++)
            {
                _clock.GetTime();
            }
            Assert.AreEqual("01:59:59", _clock.PrintTIme());

            // Advance the clock by 1 more second to reach 02:00:00
            _clock.GetTime();
            Assert.AreEqual("02:00:00", _clock.PrintTIme());
        }

        [Test]
        public void TestClockResetsAfter24Hours()
        {
            // Advance the clock by 24 hours to reach 00:00:00 again
            for (int i = 0; i < 24 * 60 * 60; i++)
            {
                _clock.GetTime();
            }
            Assert.AreEqual("00:00:00", _clock.PrintTIme());
        }


        [TearDown]
        public void TearDown()
        {
        }
    }
}
