class Bicyle : Activity{

    private double _speed;

    public Bicyle(double speed, string date, double activityLength) : base(date, activityLength){
        _speed = speed;
    }

    //override to return the _speed user provided when creating the Class instead of using the default formula
    public override double GetSpeed(){
        return _speed;
    }

}