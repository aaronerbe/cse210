class Event{
    private string _eventType;
    private string _eventTitle;
    private string _description;
    private Address _address;
    private string _date;
    private string _time;
    
    public Event(string eventType, string eventTitle, string description, Address address, string date, string time){
        _eventType = eventType;
        _eventTitle = eventTitle;
        _description = description;
        _address = address;
        _date = date;
        _time = time;
    }
    public string GetEventType(){
        return _eventType;
    }
    public string GetTitle(){
        return _eventTitle;
    }
    public string GetDescription(){
        return _description;
    }
    public Address GetAddress(){
        return _address;
    }
    public string GetDate(){
        return _date;
    }
    public string GetTime(){
        return _time;
    }

    //build description
    public string GetStandardDesc(){
        string description = $"Standard Marketing Material\n===========================\n{_eventTitle}\n{_description}\n{_date} at {_time}\n{_address.GetAddress()}";
        return description;
    }
    //set as virtual so each event type can add it's own specific details (e.g. RSVP Email for Reception)
    public virtual string GetFullDesc(){
        return "";
    }
    public string GetShortDesc(){
        string description = $"Short Marketing Material\n========================\n{_eventType}\n{_eventTitle}\n{_date}";
        return description;
    }
}