class Event{
    private string _eventType;
    private string _eventTitle;
    private string _description;
    private Address _address;
    private string _date;// = new DateTime();
    private string _time;// = new DateTime();
    
    public Event(string eventType, string eventTitle, string description, Address address, string date, string time){
        _eventType = eventType;
        _eventTitle = eventTitle;
        _description = description;
        _address = address;
        _date = date;
        _time = time;
    }

    //TODO complete building these methods
    public string GetStandardDesc(){
        string description = $"{_eventTitle}\n{_description}\n{_date} at {_time}\n{_address.GetAddress()}";
        return description;
    }
    public string GetFullDesc(){
        string description = $"{_eventType}\n{_eventTitle}\n{_description}\n{_date} at {_time}\n{_address.GetAddress()}";
        return description;
    }
    public string GetShortDesc(){
        string description = $"{_eventType}\n{_eventTitle}\n{_date}";
        return description;
    }
}