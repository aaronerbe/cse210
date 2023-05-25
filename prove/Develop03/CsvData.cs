public class CsvData{
    private string _filename = "";          //filename of the csv file
    //What seperates entries
    private string _delimiter1  = "\n";     //used to deliminate between entries (each scripture is on a newline)
    private string _delimiter2  = "~~";     //used to deliminate between reference and each verse
    private int _csvEntryCount = -1;        //number of entries (scriptures) inside the CSV file (seperated by new line \n)
    private int _csvIndex = -1;             //the index of the scripture we are working with.  Set by SetRandomEntry
    private List<string> _entries = new List<string>();     //Stores each scripture entry in a list
    private string _reference = "";         //Stores the reference of the scripture we're working with.  This gets passed to Scripture 
    private string _verses = "";            //Stores the verse(s) of the scripture we're working with.  This gets passed to Scripture 
    
    //CONSTRUCTOR
    public CsvData (string filename){
        _filename = filename;               //Sets the filename for use
        SetEntries();                      //Calls method to set the _csvEntryCount (number of scripture entries)
        SetRandomEntry();                   //Calls method to get a Random Index.  Sets the scripture we will grab and work with
        SetReference();                     //Calls method to extract the _reference
        SetVerses();                        //Calls method to extract the _verse(s)
        }

    ////METHODS
    private void SetEntries(){                          //Gets the number of scripture entries in the csv file
    string[] lines = File.ReadAllLines(_filename);      //Reads each line of the file into the array lines
    foreach (string line in lines){                     //iterate through each line
        _entries.AddRange(line.Split(_delimiter1));     //Splits line by \n and puts inside of _entries
    }
    _csvEntryCount = _entries.Count;                  //Capture the _csvEntryCount which is the number of scripture entries in the file.  
    }
    private void SetRandomEntry(){                      //Create a Random number to pick which Scripture to use out of the file
        if (_csvEntryCount > 0){                        //So long as the number of entries is > 0
            Random random = new Random();
            _csvIndex = random.Next(0,_csvEntryCount-1);  //create random number between 0 and number of entries.  -1 because count is actual length 
        }
    }
    private void SetReference(){                                //Simply set the _reference 
        _reference = _entries[_csvIndex].Split(_delimiter2)[0]; //grab the scripture (based on index), split it by "~~" and grab the 1st entry of that
        _reference = _reference.Trim();                         //cleanup incase
    }
    private void SetVerses(){                                               //Simply grab the verses
        int entryCount = _entries[_csvIndex].Split(_delimiter2).Count();    //Gets number of entries.  needed incase theres multiple verses
        for (int i = 1; i<entryCount; i++){                                 //Iterate through
            _verses += _entries[_csvIndex].Split(_delimiter2)[i]+"\n\n";    //add each entry to _verses with a \n\n at the end to separte verses
        }
    }

    public string GetReference(){   //Returns the _reference to be passed onto Scripture
        return _reference;
    }
    public string GetVerses(){      //Returns the _verses to be passed onto Scripture
        return _verses;
    }
}