class Listing : Activity{
    private List<string> _promptList = new List<string>();
    //used to track the prompt given to user so we can write it to file
    private string _prompt = "";
    private string _filepath = "reflections.txt";
    private List<string> _userList  = new List<string>();
    private string _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    public Listing(string name) : base(name){
        base.SetDescription(_description);
        BuildPromptList();
    }

    public void RunListingActivity(){
        //standard starting message, spinning animation, then prep the user
        base.DisplayStartMsg();
        Console.Clear();
        base.PauseAnimation(base._pause, "spin","Get ready...");
        Console.Clear();
        Console.WriteLine($"List as many responses as you can to the following prompt:");
        DisplayPrompt();
        base.PauseAnimation(base._pause,"countdown", "You may begin in: ");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base._duration);
        
        //while duration condition isn't met, keep reading in user entries.  Note, will sit and wait indefinately on last entry
        while (DateTime.Now < endTime){
            //giving the user prompt a > to start with
            Console.Write(">");
            _userList.Add(Console.ReadLine());
        }

        //report back to user, then display ending message
        Console.WriteLine($"You entered in {_userList.Count} items!\n");
        base.DisplayEndMsg();

        //write prompt & userlist to the file
        WriteFile();
        //clear the list so it can be run again
        _userList.Clear();
    }

    public void WriteFile(){
        FileHandler f = new FileHandler(_filepath, _prompt, _userList);
        f.WriteFile();
    }

    private void DisplayPrompt(){
        //grabs random prompt and displays it.  saved to _prompt to pass on to filehandler.
        _prompt = _promptList[GenerateRandomIndex(_promptList)];
        Console.WriteLine(_prompt);
    }
    private void BuildPromptList(){
        _promptList.Add("--- Who are people that you appreciate? --- ");
        _promptList.Add("--- What are personal strengths of yours? --- ");
        _promptList.Add("--- Who are people that you have helped this week? --- ");
        _promptList.Add("--- When have you felt the Holy Ghost this month? --- ");
        _promptList.Add("--- Who are some of your personal heroes? --- ");
    }
    private int GenerateRandomIndex(List<string> alist){
        int length = alist.Count();
        Random r = new Random();
        int randomIndex = r.Next(length);
        return randomIndex;
    }


}