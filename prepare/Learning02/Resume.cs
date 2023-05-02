//Class: Resume
//Responsibilities:
    //Keeps track of person's name and list of jobs
//Behaviors
    //Displays resume, which shows the name first, followed by displaying each of the jobs

//Class Diagrams
    //Resume:
    //_name: string
    //_jobs: List<Job>
    //Display(): void

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        
        //stepping through each job in _jobs list and calling it's DisplayJob method
        foreach (Job i in _jobs)
        {
            i.DisplayJob();
        }
    }
}
