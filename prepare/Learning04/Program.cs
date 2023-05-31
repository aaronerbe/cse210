using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "Aaron Erbe";
        string topic = "CSE210";

        Assignment a = new Assignment(name, topic);
        Console.WriteLine(a.GetSummary());

        MathAssignment m = new MathAssignment(name, topic, "7.3", "8-19");
        Console.WriteLine(m.GetHomeworkList());

        WritingAssignment w = new WritingAssignment(name, topic, "The Causes of World War II");
        Console.WriteLine(w.GetWritingInformation());

    }
}