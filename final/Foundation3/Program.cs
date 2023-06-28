using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string filename = "EventsCSV.txt";
        FileHandler f = new FileHandler(filename);
        List<Event> events = new List<Event>();
        events = f.ReadFile();

        //TODO  need to be able to selectively display an event as full, standard, etc instead of all or nothing
        StandardDisplayEvents(events);
        FullDisplayEvents(events);
        ShortDisplayEvents(events);
    }

//TODO fix displays to give extra info for event types (e.g. capacity for lectures, email for receptions, etc)
    static void StandardDisplayEvents(List<Event> events){
        foreach (Event e in events){
            Console.WriteLine($"{e.GetStandardDesc()}\n");
        }
    }
    static void FullDisplayEvents(List<Event> events){
        foreach (Event e in events){
            Console.WriteLine($"{e.GetFullDesc()}\n");
        }
    }
    static void ShortDisplayEvents(List<Event> events){
        foreach (Event e in events){
            Console.WriteLine($"{e.GetShortDesc()}\n");
        }
    }
}