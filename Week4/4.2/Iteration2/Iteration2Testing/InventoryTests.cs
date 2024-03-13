using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        private Inventory _inventory;
        private Item _item1;
        private Item _item2;

        [SetUp]
        public void SetUp()
        {
            _inventory = new Inventory();
            _item1 = new Item(new string[] { "sword" }, "Sword", "A sharp sword");
            _item2 = new Item(new string[] { "shield" }, "Shield", "A sturdy shield");

            _inventory.Put(_item1);
            _inventory.Put(_item2);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(_inventory.HasItem("sword"));
            Assert.IsTrue(_inventory.HasItem("shield"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(_inventory.HasItem("key"));
        }

        [Test]
        public void TestFetchItem()
        {
            Item fetchedItem1 = _inventory.Fetch("sword");
            Assert.IsNotNull(fetchedItem1);
            Assert.IsTrue(_inventory.HasItem("sword"));

            Item fetchedItem2 = _inventory.Fetch("shield");
            Assert.IsNotNull(fetchedItem2);
            Assert.IsTrue(_inventory.HasItem("shield"));
        }

        [Test]
        public void TestTakeItem()
        {
            Item takenItem1 = _inventory.Take("sword");
            Assert.IsNotNull(takenItem1);
            Assert.IsFalse(_inventory.HasItem("sword"));

            Item takenItem2 = _inventory.Take("shield");
            Assert.IsNotNull(takenItem2);
            Assert.IsFalse(_inventory.HasItem("shield"));
        }

        [Test]
        public void TestItemList()
        {
            string itemList = _inventory.ItemList;
            string expectedItemList = "\ta Sword (sword)\n\ta Shield (shield)";

            Assert.AreEqual(expectedItemList, itemList);
        }
    }
}
