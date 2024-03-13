using NUnit.Framework;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class LocationTest
    {
        private Player player;
        private Location location;
        private Item sword;

        [SetUp]
        public void Setup()
        {
            player = new Player("Oliver", "Cool Guy");
            location = new Location(new string[] { "Dungeon", "room" }, "Dungeon", "This is my room");
            sword = new Item(new string[] { "sword" }, "a sword", "This is a steel sword");
            player.Location = location;
        }

        [Test]
        public void TestLocationIsIdentifiable()
        {
            bool actual = location.AreYou("Dungeon");
            Assert.IsTrue(actual);
        }

        [Test]
        public void TestLocationIsNotIdentifiable()
        {
            bool actual = location.AreYou("hi");
            Assert.IsFalse(actual);
        }

        [Test]
        public void TestPlayerCanLocateLocation()
        {
            GameObject expected = location;
            GameObject actual = player.Locate("Dungeon");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestLocationCanLocateItem()
        {
            location.Inventory.Put(sword);
            GameObject expected = sword;
            GameObject actual = location.Locate("sword");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestLocationLookCommand()
        {
            string expectedDescription = "\nYou are at Dungeon\nRoom Description: This is my room\n\nItems at this location:\n";
            string actualDescription = location.FullDescription;
            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}
