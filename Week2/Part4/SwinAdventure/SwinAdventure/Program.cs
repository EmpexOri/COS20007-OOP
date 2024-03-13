using System;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2", "id3" });

            Console.WriteLine(id.AreYou("id1"));  // Output: True
            Console.WriteLine(id.AreYou("id2"));  // Output: True
            Console.WriteLine(id.AreYou("id3"));  // Output: True

            Console.WriteLine(id.FirstId);  // Output: id1

            id.AddIdentifier("id3"); // Add "id3" in lowercase
            Console.WriteLine(id.AreYou("id3"));  // Output: True

            Console.ReadLine(); // Keep the console window open
        }
    }
}
