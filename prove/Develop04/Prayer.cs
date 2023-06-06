//EXTRA
class Prayer : Activity{
    //Prayer activity = pause while user prays.  hit enter to contine then reflect and meditate listening for promptings and answers to prayer.  
    //Collect questions user is praying about
    //Collect answers and log them.  
    private string _prayer;
    private List<string> _answersList = new List<string>();
    private string _description = "This activity will help you meditate and reflect on inspirations and answers you recieve through prayer.";
    //location of the log file
    private string _prayersFile = "prayers.txt";

    //passes on the name directly to the parent.  also sets the description name in Activity class to be used by it.  
    public Prayer(string name): base (name){
        base.SetDescription(_description);
    }

    public void RunPrayerActivity(){
        //display start message and run basic get ready animation
        base.DisplayStartMsg();
        Console.Clear();
        base.PauseAnimation(base._pause,"spin", "Get ready...");
        Console.Clear();
        
        //prep user, then wait for enter to continue
        Console.WriteLine("Take time to consider what question(s) you'd like to bring to God in prayer.");
        Console.WriteLine("When you are done praying, press enter to continue.");
        Console.ReadLine();
        Console.Clear();

        //prompt and read in the question
        Console.WriteLine("What question(s) did you ask God?");
        _prayer = Console.ReadLine();
        //prompt to list out all inspirations
        Console.WriteLine("Now take time to list any inspirations or answers you feel from the Spirit");

        //while we having hit the duration limit, keep grabbing input from user
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base._duration);
        while (DateTime.Now < endTime){
            _answersList.Add(Console.ReadLine());
        }
        base.DisplayEndMsg();

        //take the prayer and answers and log them in a file
        WriteFile();
        //clear the list & prayers incase they run this again
        _answersList.Clear();
        _prayer = "";
    }

    private void WriteFile(){
        //create filehanlder class, pass on the variables and the write them out to the log
        FileHandler f = new FileHandler(_prayersFile, _prayer, _answersList);
        f.WriteFile();
    }
}