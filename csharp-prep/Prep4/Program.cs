using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> numbersList = new List<int>();
        int uNumber = 0;
        
        Console.Write("Enter a list of (positive or negative) numbers, type 0 when finshed.");

        //Get the numbers from user and build list
        do
        {
            Console.Write("Enter number: ");
            uNumber = int.Parse(Console.ReadLine());
            numbersList.Add(uNumber);
            
        } while(uNumber != 0);
    
    int count = 0;
    int sum = 0;
    float avg = 0;
    int max = 0;
    int min = 1000;
    //get sum
    foreach (int number in numbersList)
    {
        sum = sum + number;
        count ++;
        
        //get max
        if (max < number)
        {
            max = number;
        }
        //get min
        if (number < min && number > 0)
        {
            min = number;
        }
    }
    
    //get avg
    //Had to add a float here to get it to see it as a float??
    avg = ((float)sum) / (count-1);
    //resort the numbers
    numbersList.Sort();
    
    Console.WriteLine($"The sum is: {sum}");
    Console.WriteLine($"The average is: {avg}");
    Console.WriteLine($"The largest number is: {max}");
    Console.WriteLine($"Smallest positive number is: {min}");
    
    //Print out the sorted list
    foreach (int number in numbersList)
    {
        Console.WriteLine(number);
    }
    }



}