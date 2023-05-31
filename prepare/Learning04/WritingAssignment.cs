class WritingAssignment : Assignment{
    private string _title;

    public WritingAssignment(string name, string topic, string title) : base(name, topic){
        _title = title;
    }

    public string GetWritingInformation(){
        string writingInformation = ($"{GetSummary()}\n{_title} by {GetName()}");
        return writingInformation;
    }
}