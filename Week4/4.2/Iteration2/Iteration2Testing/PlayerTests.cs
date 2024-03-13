using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player _player;
        private Item _item;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("John", "A test player");
            _item = new Item(new string[] { "sword" }, "Sword", "A sharp sword");
            _player.Inventory.Put(_item);
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            // Test whether the player responds correctly to "Are You" requests
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
            Assert.IsFalse(_player.AreYou("key"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            // Test whether the player can locate items in its inventory
            GameObject foundObject = _player.Locate("sword");
            Assert.AreEqual(_item, foundObject);
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            // Test whether the player returns itself when asked to locate "me" or "inventory"
            GameObject foundObject1 = _player.Locate("me");
            GameObject foundObject2 = _player.Locate("inventory");

            Assert.AreEqual(_player, foundObject1);
            Assert.AreEqual(_player, foundObject2);
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            // Test whether the player returns null/nil when asked to locate something it does not have
            GameObject foundObject = _player.Locate("key");
            Assert.IsNull(foundObject);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            // Test whether the player's full description contains the expected text
            string expectedFullDescription = "You are John A test player\nYou are carrying:\ta Sword (sword)";
            Assert.AreEqual(expectedFullDescription, _player.FullDescription);
        }
    }
}
