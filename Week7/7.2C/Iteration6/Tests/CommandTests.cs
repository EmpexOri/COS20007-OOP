using NUnit.Framework;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class LookCommandTest
    {
        private Command look;
        private Player player;
        private Player playerWithBag;
        private Bag bag;

        private Item gem;
        private Item shovel;
        private Item diamond;

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            player = new Player("Oliver", "He's Cool");
            playerWithBag = new Player("Oliver", "Oliver has a black bag");

            gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            diamond = new Item(new string[] { "diamond" }, "a diamond", "This is a diamond");

            bag = new Bag(new string[] { "bag" }, $"Olivers bag", $"This is {player.FirstId}'s bag");
            playerWithBag.Inventory.Put(bag);
        }

        [Test]
        public void TestLookAtMe()
        {
            string output = look.Execute(player, new string[] { "look", "at", "inventory" });
            string expected = $"You are {player.Name} He's Cool\nYou are carrying:{player.Inventory.ItemList}";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtGem()
        {
            player.Inventory.Put(gem);
            string output = look.Execute(player, new string[] { "look", "at", "gem" });
            string expected = $"{gem.FullDescription}";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtUnk()
        {
            string output = look.Execute(player, new string[] { "look", "at", "gem" });
            string expected = $"gem Couldn't be found";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            player.Inventory.Put(gem);
            string output = look.Execute(player, new string[] { "look", "at", "gem", "in", "me" });
            string expected = $"{gem.FullDescription}";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            bag.Inventory.Put(gem);
            string output = look.Execute(playerWithBag, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = $"{gem.FullDescription}";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            bag.Inventory.Put(gem);
            string output = look.Execute(playerWithBag, new string[] { "look", "at", "iron", "in", "bag" });
            string expected = $"iron Couldn't be found";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            bag.Inventory.Put(gem);
            string output = look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = $"Could not find bag"; // Fix the expected value
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.AreEqual("What do you want to look at?", look.Execute(player, new string[] { "look", "around" }));
            Assert.AreEqual("What do you want to look at?", look.Execute(player, new string[] { "find", "gem" }));
        }
    }
}
