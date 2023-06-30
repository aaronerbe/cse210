using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //Read in inputs from EventsCSV to setup the types of events and set details
        string filename = "EventsCSV.txt";
        FileHandler f = new FileHandler(filename);
        //Keep list of events
        List<Event> events = new List<Event>();
        events = f.ReadFile();

        //call the function to create messages
        CreateMessages(events, f);
    }

    static void CreateMessages(List<Event> events, FileHandler f){
        //Calls the 3 different type of Message Types
        //Note, passing on filehandler for debug.  easier to read from file than console...
        foreach (Event e in events){
            StandardDisplayEvents(e,f);
            FullDisplayEvents(e,f);
            ShortDisplayEvents(e,f);
        }
    }
    
    //!NOTE I added a WriteFile to dump it to a file for easier viewing instead of just scrolling through console...  Simply for debug
    static void StandardDisplayEvents(Event e, FileHandler f){
            //Calls the Standard Description method
            Console.WriteLine($"{e.GetStandardDesc()}\n");
            f.WriteFile(e.GetStandardDesc());
    }
    static void FullDisplayEvents(Event e, FileHandler f){
            //Calls the Full Description method
            Console.WriteLine($"{e.GetFullDesc()}\n");
            f.WriteFile(e.GetFullDesc());
    }
    static void ShortDisplayEvents(Event e, FileHandler f){
            //Calls the Short Description method   
            Console.WriteLine($"{e.GetShortDesc()}\n");
            f.WriteFile(e.GetShortDesc());
    }
}