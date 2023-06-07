class Circle : Shape{
    private double _radius = 0;

    public Circle (string color, double radius) : base(color){
        _radius = radius;
    }

    public override double GetArea()
    {
        return 3.14 * _radius * _radius;
    }
}