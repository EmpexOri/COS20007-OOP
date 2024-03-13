using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class ItemTests
    {
        private Item _item;

        [SetUp]
        public void SetUp()
        {
            _item = new Item(new string[] { "sword" }, "Sword", "A sharp sword");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            // Test whether the item is identifiable by its identifiers
            Assert.IsTrue(_item.AreYou("sword"));
            Assert.IsFalse(_item.AreYou("key"));
        }

        [Test]
        public void TestShortDescription()
        {
            // Test whether the short description is in the expected format
            string expectedShortDescription = "a Sword (sword)";
            Assert.AreEqual(expectedShortDescription, _item.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            // Test whether the full description matches the item's description
            string expectedFullDescription = "A sharp sword";
            Assert.AreEqual(expectedFullDescription, _item.FullDescription);
        }
    }
}
