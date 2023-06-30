using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        //building an activity for each type.
        Running r = new Running(3.4f, "6/29/23", 56);
        Bicyle b = new Bicyle(4.63f,"6/30/23",33);
        Swimming s = new Swimming(10,"7/1/23",23);

        //Adding to the list
        activities.Add(r);
        activities.Add(b);
        activities.Add(s);

        //writing out to console by calling Activity GetSummary method
        foreach (Activity a in activities){
            Console.WriteLine(a.GetSummary());
        }

    }
}