//Simply gets and saves the Book and Verse number(s). 
public class Reference{
    private string _book;       //stores the book string
    private string _chapter;    //stores the chapter string
    private string _verseStart; //stores the starting verse
    private string _verseEnd;   //stores the ending verse

    //CONSTRUCTORS:
    //Case of Singe String (all book ch, verse(s) in one fed to it in 1 string)
    public Reference(string reference){
        ParseReferenceString(reference);    //Calls ParseReferenceString to parse out the book, ch, verses for me
    }
    //Case of Single Verse (when Scripture class can feed the pieces directly).  NOT USED
    public Reference(string book, string chapter, string verse){
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = verse;
    }
    //Case of Multiple Verses (when Scripture class can feed the pieces directly)  NOT USED
    public Reference(string book, string chapter, string verseStart, string verseEnd){
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }
    
    //METHODS:
    public string GetReference(){       //Returns the reference string in the appropriate format (handles single or multiple verses for me)
        string reference="";
        if (_verseStart==_verseEnd){    //If verseStart = verseEnd, means there's only 1 verse.  This is set in the ParseReferenceString()
            reference =$"{_book} {_chapter}:{_verseStart}";
        }else{
            reference = $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
        return reference;
    }
    private void ParseReferenceString(string reference){    //Scripture feeds a string ("John 3:16"), parses out to Book, Ch, Verse(s) accordingly
        reference = reference.Trim();                       //Trims off any extra spaces just in case
        string[] referenceArray = reference.Split(" ");     //Splits by " " and saves to an array.  This breaks it up by "Book" and "Chapter Verse(s)"
        string[] chapterVerseArray;                         //Initialize chapterVerseArray.  Used later to capture Chapter/Verse and break those up
        string [] versesArray;                              //Initialize versesArray used to capture the verses after broken away from Chapter

        if (int.TryParse(referenceArray[0], out int result)){       //Check for case when book is something like 1 Nephi instead of just John
            _book = $"{referenceArray[0]} {referenceArray[1]}";     //Captures the "1" and the "Nephi" and saves to _book
            chapterVerseArray = referenceArray[2].Split(":");       //split chapter/verse(s) apart and save into chapterVerseArray
        }
        else{                                                       //Case where it's not "1 Nephi" but something like "John" instead
            _book = referenceArray[0];                              //saves into _book
            chapterVerseArray = referenceArray[1].Split(":");       //Splits up Chapter and Verse(s) to save into chapterVerseArray
        }
        _chapter = chapterVerseArray[0];                            //grabs the 1st index and saves to _chapter
        versesArray = chapterVerseArray[1].Split("-");              //split up verses by "-" and saves to versesArry
        _verseStart = versesArray[0];                               //just grab 1st index since there's always at least 1 verse
        if (versesArray.Length>1){                                  //Check if a 2nd index exists (length > 1)
            _verseEnd = versesArray[1];                             //If so, save off to _verseEnd
        }
        else{                                                       //Else, means theres only 1 verse
            _verseEnd = _verseStart;                                //set _verseEnd as _verseStart.  This gives a clean trigger in GetReference()
        }
    }
}