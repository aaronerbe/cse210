public class Scripture{
    private List<Word> _words = new List<Word>();       //Will hold all the words in the verse(s).  Each word it's own list item
    private string _reference;                          //Will hold the reference string (Book Chapter Verse(s))
    private List<int> _wordsIndex = new List<int>();    //EXTRA:  Used for keeping track of Random.  So we don't try to hide the same index number twice.
    private List<int> _hiddenList = new List<int>();    //EXTRA:  Used to keep track of what has been hidden.  So we can temporarily hide/show.
    private bool tempShow = false;                      //EXTRA:  Boolean to toggle back and forth if we are temporarily hiding or showing

    //CONSTRUCTOR
    public Scripture(string reference, string words){
        Reference r = new Reference(reference);         //Create Reference Class and let it's Constructor parse out Book, Chapter, Verse(s)
        _reference = r.GetReference();                  //Capture reference string using GetReference method
        BuildWords(words);                              //Build the words list based on input given (saves to _words list)
    }

    private void BuildWords(string words){              //Builds the list of Word instances from the string provided
        string [] wordsArray = words.Split(" ");        //Split words by " " & put into an array
        for (int i = 0; i<wordsArray.Length; i++){      //Then step through the array and create a Word Instance for each word
            Word w = new Word(wordsArray[i]);
            _words.Add(w);                              //Add that Word class to the list
            _wordsIndex.Add(i);                         //EXTRA: Initiate original set of index numbers based on word array count.  This gets modified later as words are randomly hidden.  Used to track and not repeat the same word
        }
    }
    public void HideWords(){                        //Step through _scripture list and hide the word given by index. OR rehide previously hidden words
         
        if (tempShow == true){                              //EXTRA: If user entered " " to temporarily show all hidden words
            for (int i = 0; i<_hiddenList.Count(); i++){    //EXTRA: step through and rehide only the words that were hidden before
                _words[_hiddenList[i]].HideWord();          //EXTRA: uses the _hiddenList which keeps a running list of all words were hidding.
            }
            tempShow = false;                               //EXTRA: Flip back to false so next time around it will start hiding the next word
        }
        else{                                               //Normal Flow
            int index = RandomNumber();                     //Calls RandomNumber to get a new index number to hide
            if (index !=-1){                                //So long as index number is valid
                _words[index].HideWord();                   //Call HideWord which flips the boolean in that class to True
                _wordsIndex.Remove(index);                  //EXTRA: remove that index number from _wordsIndex so it can't be used again in RandomNumber()
                _hiddenList.Add(index);                     //EXTRA:  add the index to hiddenList to keep track of what to unhide if user enters " "
            }
        }

    }
    public void ShowWords(){                            //Used to temporarily show all the words again
        for (int i = 0; i<_hiddenList.Count(); i++){    //step through and show all words (flip them all to false)
            _words[_hiddenList[i]].ShowWord();          //Calls ShowWord which just flips the _isHidden boolean to false in Word class
        }
        tempShow = true;                                //Sets TempShow to true so when user hits Enter, it'll rehide the previously hidden words
    }

    public string GetScriptureString(){                 //Returns the Reference (Book Chapter Verses) and Words
        string scripture = "";                          //Empty out anything that was previosly stored
        for (int i = 0; i<_words.Count; i++){           //step through all words and gets the string (real or hidden) for that word
            scripture += $" {_words[i].GetWord()}";     //Appends it to scripture
        }
        scripture = $"{_reference}\n{scripture.Trim()}";  //Prepend the Reference. Add \n to put verse below reference.  trim scripture to cleanup
        return scripture;
    }
    private int RandomNumber(){                         //Generates a random number used as an index for hiding. 
        if (_wordsIndex.Count > 0){                     //Stops if there's no more words left to hide
            Random random = new Random();               
            int randomIndex = random.Next(0, _wordsIndex.Count);    //Gets random number between 0 and count of _wordsIndex
            int randomNumber = _wordsIndex[randomIndex];            //Uses that number to pick something out of the running _wordsIndex (full of numbers represending index where a word isn't hidden in our list)
            return randomNumber;
        }
        else{
            return -1;                                  //Returns -1 if there's no more left to hide
        }
    }
    public bool AllHidden(){                    //checks if all the words are hidden. 
        for (int i = 0; i<_words.Count; i++){   //steps through all words instances in the _words list and calls it's IsHidden method.
            if(!_words[i].IsHidden()){          //As soon as one word instance is NOT hidden, return fale
                return false;
            }
        }
        return true;                            //else return true
    }
}