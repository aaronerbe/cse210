using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning03 World!");
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(6);
        Fraction f3 = new Fraction (6, 7);

        //Prove constructors are working
        Console.WriteLine($"f1 -> {f1.GetFractionString()}");
        Console.WriteLine($"f2 -> {f2.GetFractionString()}");
        Console.WriteLine($"f3 -> {f3.GetFractionString()}");
    
        //prove GetTop and GetBottom are working:
        Console.WriteLine($"GetTop -> {f3.GetTop()}");
        Console.WriteLine($"GetBottom -> {f3.GetBottom()}");

        //Prove GetFractionString and GetDecimalValue are working
        Fraction f4 = new Fraction (1, 3);
        Console.WriteLine($"GetFractionString -> {f4.GetFractionString()}");
        Console.WriteLine($"GetDecimalValue -> {f4.GetDecimalValue()}");
    }
}