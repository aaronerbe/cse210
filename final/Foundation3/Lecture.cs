class Lecture:Event{
    private string _speaker;
    private int _capacity;

    //Constructor to capture everything including Lecture specific  variables (speaker and capacity)
    public Lecture(string eventType, string speaker, int capacity, string eventTitle, string description, Address address, string date, string time) :base(eventType, eventTitle, description, address, date, time){
        _speaker = speaker;
        _capacity = capacity;
    }

    //Build Full Description specific to Lecture (include seating capacity)
    public override string GetFullDesc(){
        string description = $"Full Marketing Material\n=======================\n{base.GetEventType()}\n{base.GetTitle()} by {_speaker}\n{base.GetDescription()}\nSeating Capacity: {_capacity}\n{base.GetDate()} at {base.GetTime()}\n{base.GetAddress().GetAddress()}";
        return description;
    }
}