using System;

namespace SwinAdventure
{
    // Define a class named IdentifiableObject to manage identifiers associated with game objects.
    public class IdentifiableObject
    {
        // Private field to store a list of identifiers.
        private List<string> _identifiers;

        // Constructor for creating an IdentifiableObject with an array of identifiers.
        public IdentifiableObject(string[] idents)
        {
            // Initialize the list of identifiers and add each identifier from the provided array.
            _identifiers = new List<string>();
            foreach (string s in idents)
                AddIdentifier(s);
        }

        // Public method to check if the object responds to a given identifier.
        public bool AreYou(string id)
        {
            return _identifiers.Any(_id => _id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        // Public method to add an identifier to the object.
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id);
        }

        // Public read-only property to retrieve the first identifier in the list.
        // If the list is empty, it returns an empty string.
        public string FirstId
        {
            get { return (_identifiers.Count == 0 ? "" : _identifiers[0]); }
        }
    }
}
