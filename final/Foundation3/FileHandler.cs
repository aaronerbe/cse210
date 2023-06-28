class FileHandler {
    private string _filename;
    //private List<Order> _orders = new List<Order>();
    private List<Event> _events = new List<Event>();
    private string _csvDelimiter = "~~";
    public FileHandler(string filename){
        _filename = filename;
        //ReadFile();
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
                string eventType = lineList[0];
                string eventTitle = lineList[1];
                string eventDescription = lineList[2];
                string eventDate = lineList[3];
                string eventTime = lineList[4];
                Address eventAddress = new Address(lineList[5]);
                switch (eventType){
                    case "Lecture":
                        string eventSpeaker = lineList[6];
                        int eventCapacity = int.Parse(lineList[7]);
                        Lecture l = new Lecture(eventType, eventSpeaker,eventCapacity,eventTitle, eventDescription, eventAddress, eventDate, eventTime);
                        _events.Add(l);
                        break;
                    case "Reception":
                        Reception r = new Reception(eventType, eventTitle, eventDescription, eventAddress, eventDate, eventTime);
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
}