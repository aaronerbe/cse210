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
        Prompts _p = new Prompts();
        //Create menu instance and print to display
        Menu _m = new Menu();
        //Create Entry instance
        Entry _e = new Entry();

        //Call DisplayMenu & return/save the menuOption user has selected inside of the DisplayMenu function
        _m._menuOption = DisplayMenu(_m);

        //While Loop to run until user selects 5
        while (_m._menuOption != 5)   
        {
            switch(_m._menuOption)
            {
                case 1:
                    BuildEntry(_p, _e, _currentDate);
                    //Call DisplayMenu
                    _m._menuOption = DisplayMenu(_m);   
                    break;
                case 2:
                    DisplayEntry(_e);
                    //Call DisplayMenu
                    _m._menuOption = DisplayMenu(_m); 
                    break;
                case 3:
                    //Load File
                    LoadFromFile(_e);
                    //Call DisplayMenu
                    _m._menuOption = DisplayMenu(_m); 
                    break;
                case 4:
                    //filename = GetFilename();
                    SaveToFile(_e);
                    //Call DisplayMenu
                    _m._menuOption = DisplayMenu(_m); 
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
    public static void LoadFromFile(Entry _e)
    {
        string filename = GetFileName();
        Console.WriteLine("Loading File");
        
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            //Console.WriteLine(line);
            _e._localEntries.Add(line);
        }
    }

    //SaveToFile
    public static void SaveToFile(Entry _e)
    {
        string filename = GetFileName();
        Console.WriteLine("Saving File");
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            for (int i = 0; i < _e._localEntries.Count; i++)
            {
                outputFile.WriteLine(_e._localEntries[i]);
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
    public static void DisplayEntry(Entry _e)
    {
        for (int i = 0; i < _e._localEntries.Count; i++)
        {
            Console.WriteLine(_e._localEntries[i]);
        }
    }        

    //Build New Entry
    public static void BuildEntry(Prompts _p, Entry _e, DateTime currentDate)
    {
        //EXTRA:  randomly select a prompt from the list and remove that from the list so it's not redundant
        Random rand = new Random();
        if (_p._prompt.Count > 0)
        {
            _p._randomIndex = rand.Next(_p._prompt.Count);
            _e._prompt = _p._prompt[_p._randomIndex];
            _p._prompt.RemoveAt(_p._randomIndex);
        
            //Write to display
            Console.WriteLine(_e._prompt); 
            //Collect response to Entry class to build entry
            _e._response = Console.ReadLine();
            //build entry into class
            _e._localEntries.Add($"Date: {currentDate} - Prompt: {_e._prompt} \n{_e._response}");
        }
        //EXTRA:  If no more prompt questions, just inform them there's no more and return to menu
        else
        {
            Console.WriteLine("No more prompt questions.");
        }
    }

    //DisplayMenu Function
    public static int DisplayMenu(Menu _m)
    {
        Boolean isValid = false;
        int menuOption = 0;

        while (!isValid)
        {
            Console.WriteLine();
            //write menus to screen
            foreach (string menuItem in _m.menu)
            {
                Console.WriteLine (menuItem);
            }
            //collect user input
            menuOption = int.Parse(Console.ReadLine());
            //EXTRA:   Check if it's valid (in the _validOptions list)
            isValid = _m._validOptions.Contains(menuOption);
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