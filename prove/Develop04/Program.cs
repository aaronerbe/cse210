using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //Activity a = new Activity("breath", "end Message");
        //a.SetDuration(15);
        //a.DisplayStartMsg();
        //a.Pause("countdown");
        //a.DisplayEndMsg();
        //a.SetDuration(15);
        //a.Pause("ring");

        Breathing b = new Breathing("Breathing");
        //b.RunBreathActivity();
        Reflection r = new Reflection("Reflection");
        //r.RunReflectionActivity();
        Listing l = new Listing("Listing");
        //l.RunListingActivity();
        Menu m = new Menu();
        int entry = 0;

        while (entry != 4){
            Console.Clear();
            entry = m.DisplayMenu();
            switch (entry){
                case 1:
                    b.RunBreathActivity();
                    break;
                case 2:
                    r.RunReflectionActivity();
                    break;
                case 3:
                    l.RunListingActivity();
                    break;
            }
        }
        //Console.WriteLine($"you entered {entry}");



    }


}