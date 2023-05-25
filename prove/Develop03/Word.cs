//Stores each word in a scripture verse(s).  
//Also stores the hidden version of the word.  
//Keeps a boolean to know if it's a hidden word or not.  If True, then getWord will return the _hiddenWord, else return the _word
public class Word{
    private string _word = "";          //saves the word
    private string _hiddenWord = "";    //saves the hidden word
    private Boolean _isHidden = false;  //default false till Scripture tells us otherwise.  

    //CONSTRUCTOR
    public Word(string word){
        _word = word;           //saves the word Scripture feeds us as _word
        BuildHiddenWord();      //Build the _hiddenWord now since all words will be hidden eventually.  Then it can just be managed with boolean later
    }

    //METHODS
    private void BuildHiddenWord(){             //Create a _hiddenword version of _word
        for (int i = 0; i < _word.Length; i++){     //Iterate through word to create a _ for each letter in _hiddenWord.  
            if (_word[i] != '\n'){              //check if the char is a \n.  if not, then make the char an _
                _hiddenWord += "_";
            }
            else{
                _hiddenWord += "\n";            //if it's a newline char, then leave it be (actually readd it) so paragraph between verses show properly
            }
        }
    }
    public string GetWord(){        //Return to Scripture the word string (real or hidden) based on the boolean state of _isHidden
        string word;                //create temporary string
        if (!_isHidden){            //if it's not hidden, then set the word to the real word
            word = _word;
        }else{
            word = _hiddenWord;     //if it's hidden, then set the word to the hiddenword
        }
        return word;
    }
    public void HideWord(){     //Used to set the boolean for this word to true.  This keeps _isHidden private
        _isHidden = true;
    }
    public void ShowWord(){     //Used to flip boolean back to false (used to temporarily show the words again)
        _isHidden = false;
    }
    public bool IsHidden(){     //Used to report back to Scripture the state of the boolean.  Keeps _isHidden private. Used for the AllHidden() method
        return _isHidden;
    }
}