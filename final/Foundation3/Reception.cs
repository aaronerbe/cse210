class Reception:Event{
    //TODO not sure what I'm tracking here yet.  number of rsvp?  boolean that someone rsvp?  what?
    //TODO:  "this includes an email for RSVP."  So need to change rsvp to an email string "_rsvpEmail"
    private int _rsvp;

    public Reception(string eventType, string eventTitle, string description, Address address, string date, string time) :base(eventType, eventTitle, description, address, date, time){
    }

    public void SetRSVP(int rsvp){
        _rsvp = rsvp;
    }
}