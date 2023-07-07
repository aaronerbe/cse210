class Outdoor:Event{
    private string _weatherForecast;

    public Outdoor(string weatherForecast, string eventType, string eventTitle, string description, Address address, string date, string time) :base(eventType, eventTitle, description, address, date, time){
        _weatherForecast = weatherForecast;
    }
    
    public override string GetFullDesc(){
        string description = $"Full Marketing Material\n=======================\n{base.GetEventType()} Event\n{base.GetTitle()}\n{base.GetDescription()}\nWeather Forecast for Event: {_weatherForecast}\n{base.GetDate()} at {base.GetTime()}\n{base.GetAddress().GetAddress()}";
        return description;
    }
}