using System;
//EXCEEDING REQUIREMENTS:
    //Created a Prayer Class which encourages uer to pray and then document inspiration they recieve while meditating for duration
    //Added a FileHandler Class for logging entries
        //Using FileHandler class, log Date, Question and Responses for Listing Activity
        //Using FileHandler class, log Date, Prayer and Inspirations/Answers for Prayer Activity
    //Create Menu class for cleaner handling of the menu
        //Menu handles cases of invalid entries (strings or numbers not a menu item)
    //Random questions will not repeat until the list is exhuasted.  Then it resets and will randomly run through the list again.  
    //Created an Animation Class to handle various animations.  
        //Created a breathing specific animation that shows breath in and breath out.
        //spent a lot of time creating a rotating ring but never used it.  
        


class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //Create instances of the classes.  I pass the 'name' here so it can pass to the parent in the constructor.  
        Breathing b = new Breathing("Breathing");
        Reflection r = new Reflection("Reflection");
        Listing l = new Listing("Listing");
        Prayer p = new Prayer("Prayer");
        Menu m = new Menu();
        
        int entry = 0;
        //quit is always the last entry in the menu which is the menu count - 1.  -1 because the first entry is the Menu title.  
        int menuCount = m.GetMenuCount();
        //keep running the program until user selects quit (last entry in the menu)
        while (entry != menuCount-1){
            Console.Clear();
            //call the DisplayMenu from menu class
            entry = m.DisplayMenu();
            //use switch to determine which Run Activity to call
            switch (entry){
                case 1:
                    b.RunBreatheActivity();
                    break;
                case 2:
                    r.RunReflectionActivity();
                    break;
                case 3:
                    l.RunListingActivity();
                    break;
                case 4:
                    p.RunPrayerActivity();
                    break;
            }
        }
    }
}