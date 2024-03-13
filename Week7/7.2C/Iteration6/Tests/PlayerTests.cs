using NUnit.Framework;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PlayerClassTest
    {
        private Player player;
        private Item sword;
        private Item shovel;
        private Location location;

        [SetUp]
        public void Setup()
        {
            // Create a new player for each test
            player = new Player("Oliver Rayward", "A Cool Guy");

            // Create common items
            sword = new Item(new string[] { "sword" }, "a sword", "This is a Sword");
            shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a Shovel");

            // Create a common location
            location = new Location(new string[] { "Test Location", "testroom" }, "Test Location", "A testing location");
        }

        [Test]
        public void TestPlayerIdentifiable()
        {
            // Check if the player responds to "me" and "inventory"
            Assert.IsTrue(player.AreYou("me") && player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocateItems()
        {
            // Put items in the player's inventory
            player.Inventory.Put(sword);
            player.Inventory.Put(shovel);

            // Attempt to locate the sword in the player's inventory
            GameObject itemLocated = player.Locate("sword");

            // Check if the located item is the same as the sword
            Assert.AreEqual(itemLocated, sword);
        }

        [Test]
        public void TestPlayerLocateItself()
        {
            // Attempt to locate the player itself using "me" and "inventory"
            GameObject me = player.Locate("me");
            GameObject inv = player.Locate("inventory");

            // Check if the located objects are the same as the player
            Assert.AreEqual(me, player);
            Assert.AreEqual(inv, player);
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            // Attempt to locate an item that doesn't exist in the player's inventory
            GameObject itemLocated = player.Locate("Hi");

            // Check if nothing was located (null)
            Assert.IsNull(itemLocated);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            // Put items in the player's inventory
            player.Inventory.Put(sword);
            player.Inventory.Put(shovel);

            // Expected full description
            string expected = $"You are Oliver Rayward A Cool Guy\nYou are carrying:{player.Inventory.ItemList}";

            // Check if the player's full description matches the expected description
            Assert.AreEqual(player.FullDescription, expected);
        }

        [Test]
        public void TestLocationLocateItems()
        {
            // Put items in the location's inventory
            location.Inventory.Put(sword);
            location.Inventory.Put(shovel);

            // Attempt to locate the sword in the location's inventory
            GameObject itemLocated = location.Locate("sword");

            // Check if the located item is the same as the sword
            Assert.AreEqual(itemLocated, sword);
        }

        [Test]
        public void TestLocationLocateNothing()
        {
            // Attempt to locate an item that doesn't exist in the location's inventory
            GameObject itemLocated = location.Locate("Hi");

            // Check if nothing was located (null)
            Assert.IsNull(itemLocated);
        }
    }
}
