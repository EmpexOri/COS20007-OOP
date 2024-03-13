using NUnit.Framework;
using SwinAdventure;
using System.Numerics;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class CommandTests
    {
        private Player _player;
        private Item _gem;
        private Bag _bag;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("John", "A test player");
            _gem = new Item(new string[] { "gem" }, "Gem", "A precious gem");
            _bag = new Bag(new string[] { "bag" }, "Bag", "A small bag");

            _player.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);
            _bag.Inventory.Put(_gem);
        }

        [Test]
        public void TestLookAtMe()
        {
            LookCommand lookCmd = new LookCommand();
            string[] input = { "look", "at", "inventory" };
            string expectedOutput = "You are John A test player\nYou are carrying:\ta Gem (gem)\n\ta Bag (bag)";
            string result = lookCmd.Execute(_player, input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void TestLookAtGem()
        {
            LookCommand lookCmd = new LookCommand();
            string[] input = { "look", "at", "gem" };
            string expectedOutput = "A precious gem";
            string result = lookCmd.Execute(_player, input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void TestLookAtUnk()
        {
            LookCommand lookCmd = new LookCommand();
            string[] input = { "look", "at", "unknown" };
            string expectedOutput = "unknown Couldn't be found";
            string result = lookCmd.Execute(_player, input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            LookCommand lookCmd = new LookCommand();
            string[] input = { "look", "at", "gem", "in", "inventory" };
            string expectedOutput = "A precious gem";
            string result = lookCmd.Execute(_player, input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            LookCommand lookCmd = new LookCommand();
            string[] input = { "look", "at", "gem", "in", "bag" };
            string expectedOutput = "A precious gem";
            string result = lookCmd.Execute(_player, input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            LookCommand lookCmd = new LookCommand();
            string[] input = { "look", "at", "gem", "in", "unknown" };
            string expectedOutput = "Could not find unknown";
            string result = lookCmd.Execute(_player, input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            // Remove the gem from the bag to simulate the scenario where it's not in the bag
            _bag.Inventory.Take("gem");

            LookCommand lookCmd = new LookCommand();
            string[] input = { "look", "at", "gem", "in", "bag" };
            string expectedOutput = "gem Couldn't be found";
            string result = lookCmd.Execute(_player, input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void TestInvalidLook()
        {
            LookCommand lookCmd = new LookCommand();
            string[] input = { "look", "around" }; // Invalid look command
            string expectedOutput = "Error in Look Output";
            string result = lookCmd.Execute(_player, input);
            Assert.AreEqual(expectedOutput, result);
        }
    }
}
