namespace SwinAdventure
{
    // Define a class named Inventory to manage a collection of items.
    public class Inventory
    {
        // Private field to store the list of items in the inventory.
        private List<Item> _items;

        // Constructor for creating an Inventory object.
        public Inventory()
        {
            _items = new List<Item>();
        }

        // Public property to generate a string representing the list of items in the inventory.
        // It uses LINQ to aggregate the short descriptions of items into a formatted string.
        public string ItemList
        {
            get { return _items.Aggregate("", (res, itm) => res + $"\n\t{itm.ShortDescription}"); }
        }

        // Public method to check if the inventory contains an item with a given identifier.
        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        // Public method to add an item to the inventory.
        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        // Public method to fetch an item from the inventory by its identifier.
        public Item? Fetch(string id)
        {
            return _items.Find(itm => itm.AreYou(id));
        }

        // Public method to take an item from the inventory by its identifier.
        // It removes the item from the inventory and returns it.
        public Item? Take(string id)
        {
            Item? item = Fetch(id);
            if (item is not null)
                _items.Remove(item);
            return item;
        }
    }
}
