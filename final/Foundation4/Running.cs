class Running : Activity{
    private double _distance;

    public Running(double distance, string date, double activityLength) : base(date, activityLength){
        _distance = distance;
    }
    //override to return the _distance user provided when creating the Class instea of using the default formula
    public override double GetDistance()
    {
        return _distance;
    }

}

