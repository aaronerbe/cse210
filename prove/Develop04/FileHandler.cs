class FileHandler {
    private string _filepath;
    private string _textString;
    private List<string> _textList = new List<string>();

    //always require path, string and list
    //example string would be the question asked in Listing Activity
    //example list would be the user inputs to the question in the Listing Activity
    public FileHandler(string filepath, string textString, List<string> textList){
        _filepath = filepath;
        _textString = textString;
        _textList = textList;
    }

    public void WriteFile(){
        //using true to append and create the file if it doesn't exist
        using (StreamWriter writer = new StreamWriter(_filepath, true)){
            //enter the current date/time
            writer.WriteLine(DateTime.Now);
            //these if statements are to keep it generic so an Activity class that doesn't have a string or a list can still use it.  
            //so long as the string isn't empty, write it
            if (_textString!=""){
                writer.WriteLine(_textString);
            }
            //so long as the list isn't empty, write it
            if (_textList.Count!=0){
                for (int i = 0; i<_textList.Count; i++){
                    writer.WriteLine(_textList[i]);
                }
            }
        } 
    }
}