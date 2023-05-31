class Assignment{
    private string _studentName;
    private string _topic;

    public Assignment(string name, string topic){
        _studentName = name;
        _topic = topic;
    }

    public string GetSummary(){
        string summary = $"{_studentName} - {_topic}";
        return summary;
    }

    public string GetName(){
        return _studentName;
    }
}