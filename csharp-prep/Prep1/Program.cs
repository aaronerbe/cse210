using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
        Console.Write("What is your first name? ");
    
        string f_name;    
        string l_name;
        f_name = Console.ReadLine();

        Console.Write("What is your last name? ");
        l_name = Console.ReadLine();
        Console.WriteLine();

        Console.Write($"Your name is {l_name}, {f_name} {l_name}.");
    }

}