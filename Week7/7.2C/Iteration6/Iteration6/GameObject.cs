namespace SwinAdventure
{
    // Define an abstract class named GameObject, which is a subclass of IdentifiableObject.
    public abstract class GameObject : IdentifiableObject
    {
        // Private fields to store the name and description of the game object.
        private string _name,
            _description;

        // Constructor for creating a GameObject with identifiers, a name, and a description.
        public GameObject(string[] ids, string name, string desc)
            : base(ids)
        {
            // Initialize the name and description fields.
            _name = name;
            _description = desc;
        }

        // Public read-only property to retrieve the name of the game object.
        public string Name
        {
            get { return _name; }
        }

        // Public property to generate a short description of the game object.
        // It includes the name and the first identifier.
        public string ShortDescription
        {
            get { return $"a {_name} ({FirstId})"; }
        }

        // Public virtual property to provide a full description of the game object.
        // Subclasses can override this property to provide more detailed descriptions.
        public virtual string FullDescription
        {
            get { return _description; }
        }
    }
}
