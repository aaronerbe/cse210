//TODOs
using System;
using System.Collections.Generic;

class Journal
{
    static void Main(string[] args)
    {
        //get current Date
        DateTime _currentDate = DateTime.Now;

        //Create Prompts instance
        Prompts p = new Prompts();
        //Create menu instance and print to display
        Menu m = new Menu();
        //Create Entry instance
        Entry e = new Entry();

        //Call DisplayMenu & return/save the menuOption user has selected inside of the DisplayMenu function
        m._menuOption = DisplayMenu(m);

        //While Loop to run until user selects 5
        while (m._menuOption != 5)   
        {
            switch(m._menuOption)
            {
                case 1:
                    BuildEntry(p, e, _currentDate);
                    //Call DisplayMenu
                    m._menuOption = DisplayMenu(m);   
                    break;
                case 2:
                    DisplayEntry(e);
                    //Call DisplayMenu
                    m._menuOption = DisplayMenu(m); 
                    break;
                case 3:
                    //Load File
                    LoadFromFile(e);
                    //Call DisplayMenu
                    m._menuOption = DisplayMenu(m); 
                    break;
                case 4:
                    //filename = GetFilename();
                    SaveToFile(e);
                    //Call DisplayMenu
                    m._menuOption = DisplayMenu(m); 
                    break;
                default:
                    Console.WriteLine("case default");
                    break;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Exiting");
        Console.WriteLine();

    }
    
//FUNCTIONS
    //LoadFrom File
    public static void LoadFromFile(Entry e)
    {
        string filename = GetFileName();
        Console.WriteLine("Loading File");
        
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            //Console.WriteLine(line);
            e._localEntries.Add(line);
        }
    }

    //SaveToFile
    public static void SaveToFile(Entry e)
    {
        string filename = GetFileName();
        Console.WriteLine("Saving File");
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            for (int i = 0; i < e._localEntries.Count; i++)
            {
                outputFile.WriteLine(e._localEntries[i]);
            }
                
        }
    }

    //Get Filename
    public static string GetFileName()
    {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        return filename;
    }

    //Display Entries
    public static void DisplayEntry(Entry e)
    {
        for (int i = 0; i < e._localEntries.Count; i++)
        {
            Console.WriteLine(e._localEntries[i]);
        }
    }        

    //Build New Entry
    public static void BuildEntry(Prompts p, Entry e, DateTime currentDate)
    {
        //EXTRA:  randomly select a prompt from the list and remove that from the list so it's not redundant
        Random rand = new Random();
        if (p._prompt.Count > 0)
        {
            p._randomIndex = rand.Next(p._prompt.Count);
            e._prompt = p._prompt[p._randomIndex];
            p._prompt.RemoveAt(p._randomIndex);
        
            //Write to display
            Console.WriteLine(e._prompt); 
            //Collect response to Entry class to build entry
            e._response = Console.ReadLine();
            //build entry into class
            e._localEntries.Add($"Date: {currentDate} - Prompt: {e._prompt} \n{e._response}");
        }
        //EXTRA:  If no more prompt questions, just inform them there's no more and return to menu
        else
        {
            Console.WriteLine("No more prompt questions.");
        }
    }

    //DisplayMenu Function
    public static int DisplayMenu(Menu m)
    {
        Boolean isValid = false;
        int menuOption = 0;

        while (!isValid)
        {
            Console.WriteLine();
            //write menus to screen
            foreach (string menuItem in m.menu)
            {
                Console.WriteLine (menuItem);
            }
            //collect user input
            menuOption = int.Parse(Console.ReadLine());
            //EXTRA:   Check if it's valid (in the _validOptions list)
            isValid = m._validOptions.Contains(menuOption);
            //EXTRA:  if still not valid, notify them and then it will loop the menu again
            if (!isValid)
            {
                Console.WriteLine();
                Console.WriteLine($"{menuOption} is an invalid option.  Try again. ");
            }
        }
        return menuOption;
    }
}