class Outdoor:Event{
    private string _weatherForecast;

    public Outdoor(string weatherForecast, string eventType, string eventTitle, string description, Address address, string date, string time) :base(eventType, eventTitle, description, address, date, time){
        _weatherForecast = weatherForecast;
    }
}