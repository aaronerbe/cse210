class Reception:Event{

    private string _email = "";

    public Reception(string eventType, string eventTitle, string description, Address address, string date, string time,string email) :base(eventType, eventTitle, description, address, date, time){
        _email = email;
    }

    public override string GetFullDesc(){
        string description = $"Full Marketing Material\n=======================\n{base.GetEventType()} Event\n{base.GetTitle()}\n{base.GetDescription()}\nRSVP Here: {_email}\n{base.GetDate()} at {base.GetTime()}\n{base.GetAddress().GetAddress()}";
        return description;
    }
}