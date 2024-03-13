using System;

namespace SwinAdventure
{
    class Program
    {

        static void Main(string[] args)
        {
            // Greeting info
            string name, desc;
            string help = "-look\n\nGet item lists:\n-look at me\n-look at bag\n\nGet item description:\nlook at {item}\nlook at {item} in me\nlook at {item} in bag\n\n";
            string intro = "Welcome to discount SwinAdventure\n\nCommands:\n-look\n-put [item] in bag\n\nGet Item Lists:\n-look at me\n-look at bag\n\nGet Item Descriptions:\n-look at [item] in me\n-look at [item] in bag";

            Console.WriteLine(intro);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            // End Opening

            // Setting up player

            do
            {
                Console.Write("Setting up player:\nPlayer Name: ");
                name = Console.ReadLine();
                Console.Write("Player Description: ");
                desc = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(desc))
                {
                    Console.WriteLine("Both name and description are required. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(desc));

            //Setup Locations
            Location startingLocation = new Location(new string[] { "starting_location" }, "Starting Location", "Test Region.");
            Location dungeon = new Location(new string[] { "dungeon" }, "Dungeon", "A dark and creepy dungeon.");

            Player player = new Player(name, desc, dungeon);
            // End setting up player

            // Setting up list of items

            Item helmet = new Item(new string[] { "Helmet" }, "a helmet", "This is a helmet");
            Item onering = new Item(new string[] { "Ring" }, "a precious", "This is a precious");
            Item pebble = new Item(new string[] { "Pebble" }, "a pebble", "This is a pebble, perhaps it's worth keeping");

            Item sword = new Item(new string[] { "Sword" }, "a steel sword", "This is a steel sword, ancient in looks");

            // End setting up list of items

            // Setting up inventory

            Bag bag = new Bag(new string[] { $"bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");
            player.Inventory.Put(helmet);
            player.Inventory.Put(onering);
            player.Inventory.Put(bag);
            bag.Inventory.Put(pebble);

            // End setting up inventory

            //player.Location = dungeon; // Choose player location
            //Put items in Locatio
            dungeon.Inventory.Put(sword);

            // Processing input command
            string input;

            while (true)
            {
                Console.Write("Command: ");
                input = Console.ReadLine();
                string[] inputParts = input.Split(' ');

                if (inputParts.Length == 2 && inputParts[0].ToLower() == "put")
                {
                    // Handle the "put" command
                    string itemToPut = inputParts[1];

                    if (player.Inventory.HasItem(itemToPut))
                    {
                        Item item = player.Inventory.Take(itemToPut);
                        bag.Inventory.Put(item);
                        Console.WriteLine($"You put {item.Name} in {bag.Name}.");
                    }
                    else
                    {
                        Console.WriteLine($"You don't have {itemToPut} in your inventory.");
                    }
                }
                else if (input.ToLower() == "quit")
                {
                    break;
                }
                else if (input.ToLower() == "help")
                {
                    Console.Write(help);
                }
                else
                {
                    // Execute the "look" command
                    Command l = new LookCommand();
                    Console.WriteLine(l.Execute(player, input.Split()));
                }
            }

            // End Processing input command
        }
    }
}
