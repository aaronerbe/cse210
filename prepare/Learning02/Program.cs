//Class Diagrams
    //Job
    //_company: string
    //_jobTitle: string
    //_startYear: int
    //_endYear: int
    //Display(): void

    //Resume:
    //_name: string
    //_jobs: List<Job>
    //Display(): void

using System;

class Program
{
    static void Main(string[] args)
    {
        //Creating instance of Job
        Job job1 = new Job();
        job1._company = "Franklin Building Supply";
        job1._jobTitle = "Truck Driver";
        job1._startYear = 2000;
        job1._endYear = 2007;

        Job job2 = new Job();
        job2._company = "Micron Technology";
        job2._jobTitle = "Engineer";
        job2._startYear = 2007;
        job2._endYear = 2023;

        //Commenting out and replacing with Resume list
        //job1.DisplayJob();
        //job2.DisplayJob();

        //Creating instance of Resume
        Resume resume = new Resume();
        resume._name = "Aaron Erbe";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        //printing resume
        resume.DisplayResume();
    }
}