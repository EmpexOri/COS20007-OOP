using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Your Name:");
            Message[] messages = new Message[]
            {
                new Message("Welcome Back"),
                new Message("What a lovely name"),
                new Message("Great Name"),
                new Message("Oh Hi"),
                new Message("That's a silly name")
            };

            string inputName = Console.ReadLine();

            if (inputName != null)
            {
                string nameLower = inputName.ToLower();

                Message myMessage;

                if (nameLower == "oliver")
                {
                    myMessage = messages[0];
                }
                else if (nameLower == "lorraine")
                {
                    myMessage = messages[1];
                }
                else if (nameLower == "lucien")
                {
                    myMessage = messages[2];
                }
                else if (nameLower == "bella")
                {
                    myMessage = messages[3];
                }
                else
                {
                    myMessage = messages[4];
                }

                myMessage.Print();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No input provided.");
            }
        }
    }
}
