using System;

namespace HelloWorld
{
    class Hello
    {

        static string Msg = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Your Message:");
            Msg = Console.ReadLine();

            if (string.IsNullOrEmpty(Msg)) 
            {
                Main(args);
                Console.WriteLine("Please ReEnter Your Message, A Message Cannot Be Blank");
            } 
            else
            {
                Writer(args);
            }
        }
        static void Writer(string[] args)
        {
            Console.WriteLine(Msg);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(); // Wait for user input before exiting
        }
    }
}