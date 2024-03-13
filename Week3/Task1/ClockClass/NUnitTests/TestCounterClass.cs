using System;
using NUnit.Framework;
using Clock; // Make sure this namespace matches the one in the ClockClass file

namespace Clock.Tests
{
    [TestFixture]
    public class CounterClassTests
    {
        private Counter _counter;

        [SetUp]
        public void SetUp()
        {
            _counter = new Counter("TestCounter");
        }

        [Test]
        public void TestCounterStartsAtZero()
        {
            // Perform assertions to test that the counter starts at 0
            Assert.AreEqual(0, _counter.Ticks);
        }

        [Test]
        public void TestCounterIncrements()
        {
            // Perform assertions to test that the counter increments properly
            _counter.Increment();
            Assert.AreEqual(1, _counter.Ticks);
        }

        [Test]
        public void TestCounterResets()
        {
            // Perform assertions to test that the counter resets properly
            _counter.Increment();
            _counter.Reset();
            Assert.AreEqual(0, _counter.Ticks);
        }

        [Test]
        public void TestCounterResets5Times()
        {
            for (int i = 0; i < 5; i++)
            {
                _counter.Increment();
            }
            _counter.Reset();
            Assert.AreEqual(0, _counter.Ticks);
        }

        [Test]
        public void TestCounterResets10Times()
        {
            for (int i = 0; i < 10; i++)
            {
                _counter.Increment();
            }
            _counter.Reset();
            Assert.AreEqual(0, _counter.Ticks);
        }

        // Add more tests as needed

        [TearDown]
        public void TearDown()
        {
            // Clean up resources if needed
        }
    }
}
