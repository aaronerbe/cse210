public class Entry
{
    //localEntries saves entries user inputs and is where entries are stored when loaded from a file
    public List<string> _localEntries = new List<string>();
    //stores the prompt given to the user
    public string _prompt = "";
    //response is storing what the user relies to the prompt
    public string _response = "";
    //get current Date
    public DateTime _currentDate = DateTime.Now;

   //Display Entries
    public void DisplayEntry(Entry e)
    {
        for (int i = 0; i < e._localEntries.Count; i++)
        {
            string[] parts = e._localEntries[i].Split("~~");
            Console.WriteLine($"{parts[0]}\n{parts[1]}");
        }
    }    

    //Build New Entry
    public void BuildEntry(Prompts p, Entry e)
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
            Console.Write(">");
            //Collect response to Entry class to build entry
            e._response = Console.ReadLine().Trim();
            //build entry into class
            e._localEntries.Add($"Date: {_currentDate.ToString("MM-dd-yyyy")} - Prompt: {e._prompt}~~{e._response}");
        }
        //EXTRA:  If no more prompt questions, just inform them there's no more and return to menu
        else
        {
            Console.WriteLine("No more prompt questions.");
        }
    }

}
