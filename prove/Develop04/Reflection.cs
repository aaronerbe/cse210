class Reflection : Activity{
    List<string> _promptList = new List<string>();
    List<string> _questionList = new List<string>();
    //time to countdown before starting
    int _countdownTimer = 5;


    public Reflection(string name) : base(name){
        BuildPromptList();
        BuildQuestionList();
        //base.SetName(name);
    }

    public void RunReflectionActivity(){
        base.DisplayStartMsg();
        //Animation a = new Animation();
        //Console.Clear();
        base.PauseAnimation(_countdownTimer, "countdown");
        Console.Clear();
        DisplayPrompt();
        Console.WriteLine("When you have something in mind, press enter");
        Console.ReadLine();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base._duration);
        while (DateTime.Now < endTime){
            DisplayQuestion();
            base.PauseAnimation(_countdownTimer,"pingpong");
            Console.Write("\n");
        }
        base.DisplayEndMsg();
    }
    private void DisplayPrompt(){
        //GenerateRandomIndex(_promptList);
        Console.WriteLine(_promptList[GenerateRandomIndex(_promptList)]);
    }
    private void DisplayQuestion(){
        Console.Write(_questionList[GenerateRandomIndex(_questionList)]);
    }
    private void BuildPromptList(){
        _promptList.Add("---Think of a time when you stood up for someone else.---");
        _promptList.Add("---Think of a time when you did something really difficult.---");
        _promptList.Add("---Think of a time when you helped someone in need.---");
        _promptList.Add("---Think of a time when you did something truly selfless.---");
    }
    private void BuildQuestionList(){
        _questionList.Add("Why was this experience meaningful to you?");
        _questionList.Add("Have you ever done anything like this before?");
        _questionList.Add("How did you get started?");
        _questionList.Add("How did you feel when it was complete?");
        _questionList.Add("What made this time different than other times when you were not as successful?");
        _questionList.Add("What is your favorite thing about this experience?");
        _questionList.Add("What could you learn from this experience that applies to other situations?");
        _questionList.Add("What did you learn about yourself through this experience?");
        _questionList.Add("How can you keep this experience in mind in the future?");
    }
    private int GenerateRandomIndex(List<string> alist){
        int length = alist.Count();
        Random r = new Random();
        int randomIndex = r.Next(length);
        return randomIndex;
    }
}