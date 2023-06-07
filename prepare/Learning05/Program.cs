using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning05 World!");
        List<Shape> shapesList = new List<Shape>();
        Square s = new Square("red", 5);
        Rectangle r = new Rectangle("green", 6,2);
        Circle c = new Circle("blue", 8);
        //Console.WriteLine(s.GetArea());
        //Console.WriteLine(s.GetColor());
        //Console.WriteLine(r.GetArea());
        //Console.WriteLine(r.GetColor());
        //Console.WriteLine(c.GetArea());
        //Console.WriteLine(c.GetColor());
    
        shapesList.Add(s);
        shapesList.Add(r);
        shapesList.Add(c);

        foreach (Shape shape in shapesList){
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    
    }
}