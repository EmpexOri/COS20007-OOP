using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class BagTests
    {
        private Bag bag1;
        private Bag bag2;
        private Item item;

        [SetUp]
        public void Setup()
        {
            // Create Bag objects and an Item for testing
            bag1 = new Bag(new string[] { "bag1" }, "Bag 1", "Description of Bag 1");
            bag2 = new Bag(new string[] { "bag2" }, "Bag 2", "Description of Bag 2");
            item = new Item(new string[] { "item1" }, "Item 1", "Description of Item 1");

            // Put bag2 into bag1's plus Item inventory
            bag1.Inventory.Put(bag2);
            bag1.Inventory.Put(item);
        }

        [Test]
        public void TestBagLocatesItems()
        {
            // Test locating items in bag1
            bag1.Inventory.Put(item);
            Assert.AreEqual(item, bag1.Locate("item1"));
        }

        [Test]
        public void TestBagLocatesItself()
        {
            // Test locating bag1 itself
            Assert.AreEqual(bag1, bag1.Locate("bag1"));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            // Test locating something that bag1 doesn't have
            Assert.IsNull(bag1.Locate("nonexistent"));
        }

        [Test]
        public void TestBagFullDescription()
        {
            // Test the full description of bag1
            string expectedDescription = "Bag 1 containing:\n\ta Bag 2 (bag2)\n\ta Item 1 (item1)";
            Assert.AreEqual(expectedDescription, bag1.FullDescription);
        }

        [Test]
        public void TestBagInBag()
        {
            // Test locating bag2 in bag1
            Assert.AreEqual(bag2, bag1.Locate("bag2"));

            // Test locating other items in bag1
            bag1.Inventory.Put(item);
            Assert.AreEqual(item, bag1.Locate("item1"));

            // Test that bag1 cannot locate items in bag2
            Assert.IsNull(bag1.Locate("item_in_bag2"));
        }
    }
}
