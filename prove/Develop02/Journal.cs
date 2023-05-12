using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public string _filename = "";

    //LoadFrom File
    public void LoadFromFile(Entry e)
    {
        GetFileName();
        //EXTRA - check if filename exists first.  
        if (File.Exists(_filename))
        {
            Console.WriteLine("\n Loading File");
            string[] lines = System.IO.File.ReadAllLines(_filename);
            foreach (string line in lines)
            {
                //Console.WriteLine(line);
                e._localEntries.Add(line);
            }
        }
        else{
            Console.WriteLine($"\n{_filename} doesn't exist.\n");
        }
    }
    
    //Get Filename Method
    string GetFileName()
    {
        Console.WriteLine("What is the filename?");
        _filename = Console.ReadLine();
        return _filename;
    }

    //SaveToFile as CSV
    public void SaveToFile(Entry e)
    {
        //string filename = GetFileName();
        GetFileName();
        Console.WriteLine("Saving File");
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            for (int i = 0; i < e._localEntries.Count; i++)
            {
                outputFile.WriteLine(e._localEntries[i]);
            }
        }
    }
}