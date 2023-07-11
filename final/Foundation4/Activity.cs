class Activity{
    //setting as DateTime so format can be manipulated
    private DateTime _date;
    private double _activityLength;  //in minutes

    public Activity(string date, double activityLength){
        //capture input as string and parse to DateTime
        _date = DateTime.Parse(date);
        _activityLength = activityLength;
    }

    //Setup default formulas as virtuals
    public virtual double GetDistance(){
        return (GetSpeed() * GetActivityLength())/60;
    }
    public virtual double GetSpeed(){
        return (GetDistance() / GetActivityLength())*60;
    }
    private double GetPace(){
        return 60/GetSpeed();
    }
    private double GetActivityLength(){
        return _activityLength;
    }
    
    //GetSummary to return back date on each activity
    //using ToString to set format for all numbers to keep it clean.
    //Also add a \t for clean formatting
    public string GetSummary(){
        return $"{_date.ToString("dd MMM yyyy")}\t{GetType().Name}  \t({GetActivityLength()} min)\t{GetDistance().ToString("0.00")} miles\t{GetSpeed().ToString("0.00")} mph\t{GetPace().ToString("0.00")} min per mile";
    }
}