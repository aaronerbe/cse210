class Listing : Activity{
    List<string> _promptList = new List<string>();
    List<string> _userList  = new List<string>();
    //time to countdown before starting
    int _countdownTimer = 5;
    int _numberOfUserList;

    public Listing(string name) : base(name){
        BuildPromptList();
    }

    public void RunListingActivity(){
        base.DisplayStartMsg();
        Console.Write("Get ready");
        base.PauseAnimation(_countdownTimer, "pingpong");
        Console.Clear();
        Console.WriteLine($"List as many responses as you can to the following prompt:");
        DisplayPrompt();
        base.PauseAnimation(_countdownTimer,"countdown");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base._duration);
        while (DateTime.Now < endTime){
            _userList.Add(Console.ReadLine());
        }
        Console.WriteLine($"You entered in {_userList.Count} items!");
        base.DisplayEndMsg();
    }

    private void DisplayPrompt(){
        Console.WriteLine(_promptList[GenerateRandomIndex(_promptList)]);
    }
    private void BuildPromptList(){
        _promptList.Add("Who are people that you appreciate?");
        _promptList.Add("What are personal strengths of yours?");
        _promptList.Add("Who are people that you have helped this week?");
        _promptList.Add("When have you felt the Holy Ghost this month?");
        _promptList.Add("Who are some of your personal heroes?");
    }
    private int GenerateRandomIndex(List<string> alist){
        int length = alist.Count();
        Random r = new Random();
        int randomIndex = r.Next(length);
        return randomIndex;
    }


}