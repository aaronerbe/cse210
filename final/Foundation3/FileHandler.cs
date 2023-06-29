class FileHandler {
    private string _filename;
    private string _outputFile = "test.txt";
    //private List<Order> _orders = new List<Order>();
    private List<Event> _events = new List<Event>();
    private string _csvDelimiter = "~~";
    public FileHandler(string filename){
        _filename = filename;
        // Check if the file exists
        if (File.Exists(_outputFile))
        {
            // clear the file
            File.WriteAllText(_outputFile, "");
        }
    }
    public List<Event> ReadFile(){
        //Read in a file containing the video title, author, length, and all comments with names of commenters.  
        //Format:  CustomerName~~CustomerAddress~~CustomerCountry~~Item1Name~~Item1ID~~Item1Price~~Item1Quantity
        using (StreamReader reader = new StreamReader(_filename)){
            //line is used to store each line in the csv
            string line;
            //lineList is used to store each entry on the line (seperated by delimiter)
            string[] lineList;

            //while not at the end of the file, read in a new line
            while ((line = reader.ReadLine()) != null){
                //then break up by delimiter and save in a list
                lineList = line.Split(_csvDelimiter);  
                //capture the common info
                string eventType = lineList[0];
                string eventTitle = lineList[1];
                string eventDescription = lineList[2];
                string eventDate = lineList[3];
                string eventTime = lineList[4];
                Address eventAddress = new Address(lineList[5]);
                //Depending on event type, capture event specific info
                switch (eventType){
                    case "Lecture":
                        string eventSpeaker = lineList[6];
                        int eventCapacity = int.Parse(lineList[7]);
                        //create even specific object capturing everything
                        Lecture l = new Lecture(eventType, eventSpeaker,eventCapacity,eventTitle, eventDescription, eventAddress, eventDate, eventTime);
                        //capture in events list
                        _events.Add(l);
                        break;
                    case "Reception":
                        string email = lineList[6];
                        Reception r = new Reception(eventType, eventTitle, eventDescription, eventAddress, eventDate, eventTime, email);
                        _events.Add(r);
                        break;
                    case "Outdoor":
                        string eventforecast = lineList[6];
                        Outdoor o = new Outdoor(eventforecast,eventType, eventTitle, eventDescription, eventAddress, eventDate, eventTime);
                        _events.Add(o);
                        break;
                }
            }
        }
        return _events;
    }
    public void WriteFile(string textString){
        //using true to append and create the file if it doesn't exist
        using (StreamWriter writer = new StreamWriter(_outputFile, true)){
            writer.WriteLine(textString);
            writer.WriteLine();
        } 
    }
}