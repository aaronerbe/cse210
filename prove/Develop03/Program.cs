//Exceeding Requirements:
    //1.  Keep track of the Random hidden words to ensure we don't repeat
    //2.  Pull the scriptures from a csv file ("scriptures.txt")
        //Randomly selects 1 entry from this file and uses that.
    //3.  Added option for user to entere space (" ").  This temporarily shows all the hidden words
        //On next "Enter" it re-hides all the words that were previously hidden.
        //Subsequent "Enter" will continue hiding words as normal
    //4.  Minor Display cleanup.  
        //Verses start on new line under Book & Chapter
        //Cleaned up Options menu some for readability.  

class Program
{    
    static void Main(string[] args){
        string filename = "scriptures.txt";     //EXTRA:  csv filename
        string userEntry = "";                  //initiate userEntry variable
        CsvData csv = new CsvData(filename);    //EXTRA:  create instance of csv Class
        Scripture s = new Scripture(csv.GetReference(), csv.GetVerses());   //create Instance of Scripture Class
        bool AllHidden = s.AllHidden();         //initialize AllHidden boolean.  used to track and auto exit once everything is hidden

        Console.Clear();                        //clears console
        while (!AllHidden && userEntry.ToLower() != "quit"){    //Main While Loop.  Will run until user types quit or AllHidden = true
            Console.Clear();                    
            AllHidden = s.AllHidden();          //call Scripture Method AllHidden() to determine if everything is hidden or not
                
            if (userEntry == " "){              //EXTRA:  catch if user enters space to temporarily show hidden words
                s.ShowWords();                  //If so, run the Scripture Method to show words
            }          
            
            Console.WriteLine(s.GetScriptureString());  //Displays the Scripture String which is Reference Book Chapter Versus Words
            s.HideWords();                      //Hides a random word  3x to hid 3 random words
            s.HideWords();
            s.HideWords();

            //Display the options for the user.  
            Console.WriteLine("\nOptions: \n---------------------------------------------------- \n+ Press Enter To Continue \n+ Enter <space> ' ' To Temporarily Show Hidden Words \n+ Type 'quit' To Finish \n----------------------------------------------------");
            userEntry = Console.ReadLine();     //capture what user inputs
            
        }
        //TESTING ONLY:
        //WordTestBench();
        //ReferenceTestBench();
        //ScriptureTestBench();
        //CSVTestBench();
    }

    //THIS WERE USED FOR TESTING ONLY TO VERIFY MY METHODS AND CLASSES WERE WORKING AS EXPECTED.  
    static void CSVTestBench(){
        CsvData csv = new CsvData("scriptures.txt");
        //Console.WriteLine(csv._csvEntryCount);
        //Console.WriteLine(csv._csvIndex);
        //Console.WriteLine(csv._entries[csv._csvIndex]);
        Console.WriteLine(csv.GetReference());
        Console.WriteLine(csv.GetVerses());
    }
    static void WordTestBench(){
        Word w = new Word("test");
        Console.WriteLine($"test buildHiddenWord & getWord {w.GetWord()}");
        w.HideWord();
        Console.WriteLine($"test getWord after hiding {w.GetWord()}");
        Console.WriteLine($"Test isHidden {w.IsHidden()}");
    }
    static void ReferenceTestBench(){
        Reference rSingle = new Reference("John", "3", "16");
        Reference rMultiple = new Reference("John", "3", "16", "17");
        Reference rStringSingle = new Reference("1 John 3:16");
        Reference rStringMultiple = new Reference("John 3:16-17");
        Console.WriteLine($"test getReference single verse {rSingle.GetReference()}");
        Console.WriteLine($"test getReference multiple verse {rMultiple.GetReference()}");
        Console.WriteLine($"test getReference string reference {rStringSingle.GetReference()}");
        Console.WriteLine($"test getReference string reference {rStringMultiple.GetReference()}");
    }
    static void ScriptureTestBench(){
        Scripture sCase1 = new Scripture("1 John 3:16", "For God so loved the world that he gave his only Begotten Son.");
        Scripture sCase2 = new Scripture("1 John 3:16-17", "For God so loved the world that he gave his only Begotten Son.");
        Scripture sCase3 = new Scripture("John 3:16", "For God so loved the world that he gave his only Begotten Son.");
        Scripture sCase4 = new Scripture("John 3:16-17", "For God so loved the world that he gave his only Begotten Son.");
        //test Hide Words
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
        sCase1.HideWords();
        Console.WriteLine(sCase1.GetScriptureString());
        Console.WriteLine(sCase1.AllHidden());
    }
}