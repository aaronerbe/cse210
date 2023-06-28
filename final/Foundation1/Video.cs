class Video{
    private string _title;
    private string _author;
    private int _length;
    //list of comment classes stored in the video class
    private List<Comment> _comments = new List<Comment>();
    private int _commentCount;

    //all of this is passed from the filehandler (when reading in csv).
    public Video(string title, string author, int length, List<Comment> comments){
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
        _commentCount = _comments.Count();
    }

    //
    public string GetVideoTitle(){
        return _title;
    }
    public string GetVideoAuthor(){
        return _author;
    }
    public int GetVideoLength(){
        return _length;
    }
    public int GetCommentCount(){
        //return _commentCount;
        return _comments.Count();
    }

    public List<Comment> GetCommentsList(){
        return _comments;
    }

    public void DisplayVideoInfo(){
        string line;
        line = $"{_title}\n{_author}\n{_length}\n{_commentCount}\n";
        
        if (_commentCount != 0){
            for (int i = 0; i<(_commentCount); i++){
            line += $"{_comments[i].GetComment()}\n";
            }
        }
        Console.WriteLine($"{line}");
    }
}


