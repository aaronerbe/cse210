using System;

class Program
{
    static void Main(string[] args)
    {
        

        int rNumber;
        int uNumber;
        int count = 0;
        string play = "yes";

        //Create Random number

        Random randomGenerator = new Random();
        rNumber = randomGenerator.Next(1,100);

        while (play == "yes")
            {
            do
            {
                Console.Write("What is your guess? ");
                uNumber = int.Parse(Console.ReadLine());
                count ++;
                
                if (uNumber > rNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (uNumber < rNumber)
                {
                    Console.WriteLine("Higher");
                }
                //Console.Write("What is your guess? ");
                //uNumber = int.Parse(Console.ReadLine());
                //count ++;
            } while (uNumber != rNumber);

            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {count} guesses.");
            Console.Write("Would you look to play again? ");
            play = Console.ReadLine();
                if (play == "yes")
                    {
                        rNumber = randomGenerator.Next(1,100);
                        count = 0;
                    }
            }
    }
}