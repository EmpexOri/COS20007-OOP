namespace SwinAdventure
{
    // Define a class named Item that inherits from GameObject.
    public class Item : GameObject
    {
        // Constructor for creating an Item object.
        public Item(string[] idents, string name, string desc)
            : base(idents, name, desc) { }

        // Public method to compare equality with another Item object.
        // It checks if the first identifier of this item matches the identifier of the other item.
        public bool Equals(Item itm)
        {
            return this.AreYou(itm.FirstId);
        }
    }
}
