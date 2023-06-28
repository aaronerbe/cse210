class Lecture:Event{
    private string _speaker;
    private int _capacity;

    public Lecture(string eventType, string speaker, int capacity, string eventTitle, string description, Address address, string date, string time) :base(eventType, eventTitle, description, address, date, time){
        _speaker = speaker;
        _capacity = capacity;
    }
}