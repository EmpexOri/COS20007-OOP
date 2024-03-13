using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace SwinAdventure
{
    public class PlayerClassTest
    {
        Player player = new Player("Oliver Rayward", "A Cool Guy");
        Item shovel = new Item(new string[] { "hammer" }, "a hammer", "This is a Hammer");
        Item sword = new Item(new string[] { "sword" }, "a sword", "This is a Sword");
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestPlayerIdentifiable()
        {
            Assert.IsTrue(player.AreYou("me") && player.AreYou("inventory"));

        }

        [Test]
        public void TestPlayerLocateItems()
        {
            var result = false;
            player.Inventory.Put(sword);
            var itemsLocated = player.Locate("sword");
            if (sword == itemsLocated)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [Test]
        public void TestPlayerLocateItself()
        {
            var me = player.Locate("me");
            var inv = player.Locate("inventory");
            var result = false;

            if (me == player || inv == player)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            var me = player.Locate("Hi");
            Assert.IsNull(me);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            player.Inventory.Put(sword);
            player.Inventory.Put(shovel);
            string expected = $"You are {player.Name}, you are carrying\n{player.Inventory.ItemList}";
            Assert.AreEqual(player.FullDescription, expected);
        }
    }
}