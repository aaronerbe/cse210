class FileHandler {
    private string _filename;
    private List<Video> _videoList = new List<Video>();
    private string _csvDelimiter = "~~";
    public FileHandler(string filename){
        _filename = filename;
    }

    public List<Video> ReadFile(){
        //Read in a file containing the video title, author, length, and all comments with names of commenters.  
        //Format:  title~~author~~length~~comment1 name~~comment1~...
        using (StreamReader reader = new StreamReader(_filename)){
            //line is used to store each line in the csv
            string line;
            //lineList is used to store each entry on the line (seperated by delimiter)
            string[] lineList;
            
            //some variables to capture pieces of the entry
            string title;
            string author;
            int length;

            //while not at the end of the file, read in a new line
            while ((line = reader.ReadLine()) != null){
                //then break up by delimiter and save in a list
                lineList = line.Split(_csvDelimiter);  
                
                //build the comments list first  
                List<Comment> commentList = new List<Comment>();
                //only proceed catching comments if there is comments (count > 3)
                if (lineList.Count()>3){
                    //step through from 3 + to capture each commenter name + comment
                    for (int i = 3; i< lineList.Count()-1; i++){
                        //capture name
                        string cName = lineList[i];
                        //iterate to get the comment
                        i++;
                        string cComment = lineList[i];
                        //create a comment class, then add it to the list of comments
                        Comment comment = new Comment (cName, cComment);
                       commentList.Add(comment);
                    }
                }
                
                //now build video class and pass the comments list to it
                title = lineList[0];
                author = lineList[1];
                length = int.Parse(lineList[2]);
                _videoList.Add(new Video(title,author,length,commentList));
            }
        }
        //return the list of video classes
        return _videoList;
    }
}