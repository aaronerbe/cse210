class Swimming : Activity{
    private int _laps;

    public Swimming(int laps, string date, double activityLength) : base(date, activityLength){
        _laps = laps;
    }
    //override to use laps to get distance
    public override double GetDistance(){
        return (_laps * 50.0/1000.0 * 0.62);
    }

}