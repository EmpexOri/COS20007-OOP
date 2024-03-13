using System;

namespace Program
{
    class Begin
    {

        static void Main()
        {
            String Choice;
            Console.WriteLine("Would You Like To Average The Following Values:\n5, 4, 1, 10, 50, 15, 7\nY/N?");
            Choice = Console.ReadLine();

            if(Choice.Trim().ToUpper() == "Y")
            {
                Average();
            } else
            {
                Main();
            }
        }
        static void Average()
        {
            int[] arr = { 5, 4, 1, 10, 50, 15, 7 };

            int i = 0;
            int sum = 0;
            float average = 0.0F;

            for (i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            average = sum / arr.Length;
            if (average >= 10)
            {
                Console.WriteLine(average + " Double Digits");
            }
            else if (average <= 10)
            {
                Console.WriteLine(average + " Single Digits");
            }

        }
    }
}
