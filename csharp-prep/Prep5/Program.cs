using System;

class Program
{
    static void Main(string[] args)
    {

        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int sqr = SquareNumber(userNumber);
        DisplayResult(userName, sqr);

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int userNumber = int.Parse(Console.ReadLine());
            return userNumber;
        }

        static int  SquareNumber(int userNumber)
        {
            int sqr = userNumber * userNumber;
            return sqr;
        }

        static void DisplayResult(string name, int sqr)
        {
            Console.WriteLine($"{name}, the square of your number is {sqr}");
        }
    }
}