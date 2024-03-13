using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class TestIdentifiableObject
    {
        private IdentifiableObject _identifiable;

        [SetUp]
        public void SetUp()
        {
            _identifiable = new IdentifiableObject(new string[] { "id1", "id2" });
        }

        [Test]
        public void TestAreYou_ValidIdentifier_ReturnsTrue()
        {
            bool result = _identifiable.AreYou("id1");
            Assert.IsTrue(result, "Expected true for valid identifier.");
        }

        [Test]
        public void TestAreYou_InvalidIdentifier_ReturnsFalse()
        {
            bool result = _identifiable.AreYou("id3");
            Assert.IsFalse(result, "Expected false for invalid identifier.");
        }

        [Test]
        public void TestFirstId_MultipleIdentifiers_ReturnsFirstIdentifier()
        {
            string result = _identifiable.FirstId;
            Assert.AreEqual("id1", result, "Expected first identifier.");
        }

        [Test]
        public void TestAddIdentifier_NewIdentifier_AddsIdentifier()
        {
            _identifiable.AddIdentifier("id3");
            bool result = _identifiable.AreYou("id3");
            Assert.IsTrue(result, "Expected true for added identifier.");
        }

        [TestCase("ID1")]
        [TestCase("ID2")]
        public void TestAreYou_CaseInsensitive(string id)
        {
            bool result = _identifiable.AreYou(id);
            Assert.IsTrue(result, "Expected true for case-insensitive identifier.");
        }

        [Test]
        public void TestFirstIDWithNoIDs_NoIdentifiers_ReturnsEmptyString()
        {
            // Create an IdentifiableObject with no identifiers
            IdentifiableObject identifiable = new IdentifiableObject(new string[] { });

            // Check if FirstId returns an empty string
            string result = identifiable.FirstId;
            Assert.AreEqual("", result, "Expected an empty string for no identifiers.");
        }
    }
}
