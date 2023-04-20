using System;

class Program
{
    static void Main(string[] args)
    {
        bool pass = true;

        Console.Write("What is your grade percentage? ");
        int grade = int.Parse(Console.ReadLine());

        //if(grade>=90)
        //{
        //    Console.WriteLine("You got an A");
        //}
        //else if (grade >=80 && grade < 90)
        //{
        //    Console.WriteLine("You got a B");
        //}
        //else if (grade >=70 && grade < 80)
        //{
        //    Console.WriteLine("You got a C");
        //}
        //else if (grade >=60 && grade < 70)
        //{
        //    Console.WriteLine("You got a D")
        //    pass = false;
        //}
        //else
        //{
        //    Console.WriteLine("You got an F");
        //    pass = false;
        //}

        string letter;
        
        //Determine letter grade
        if(grade>=90)
        {
            letter = "A";
        }
        else if (grade >=80 && grade < 90)
        {
            letter = "B";
        }
        else if (grade >=70 && grade < 80)
        {
            letter = "C";
        }
        else if (grade >=60 && grade < 70)
        {
            letter = "D";
            pass = false;
        }
        else
        {
            letter = "F";
            pass = false;
        }

        //determine if it's a + or -
        int l_digit = grade % 10;
        string pm = "";
        if (grade < 97 || grade !< 60)
        {
            if (l_digit >= 7)
            {
                pm = "+";
            }
            else if (l_digit <3)
            {
                pm = "-";
            }
        }


        //print out letter grade
        Console.WriteLine($"You got a {letter}{pm}");

        if (pass == true)
        {
            Console.WriteLine("You passed the class!");
        }
        else
        {
            Console.WriteLine("I'm sorry, you didn't pass the class.  You'll do better next time!");
        }
    }
}