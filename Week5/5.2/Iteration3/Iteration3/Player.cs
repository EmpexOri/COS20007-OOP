using System;

namespace SwinAdventure
{
    // Define a class named Player that inherits from GameObject.
    public class Player : GameObject
    {
        // Private field to store the player's inventory.
        private Inventory _inventory;

        // An array of default identifiers for the player.
        private static readonly string[] DefaultIndents = { "me", "inventory" };

        // Constructor for creating a Player object.
        public Player(string name, string desc)
            : base(DefaultIndents, name, desc)
        {
            // Initialize the player's inventory.
            _inventory = new Inventory();
        }

        // Method to locate a game object by its identifier.
        // It checks if the identifier matches the player's or any item in the inventory.
        public GameObject? Locate(string id)
        {
            return AreYou(id) ? this : _inventory.Fetch(id);
        }

        // Override the FullDescription property to provide a complete description of the player.
        // It includes the player's name, description, and the list of items they are carrying.
        public override string FullDescription
        {
            get { return $"You are {Name} {Description}\nYou are carrying:{_inventory.ItemList}"; }
        }

        // Public property to access the player's inventory.
        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
    }
}
