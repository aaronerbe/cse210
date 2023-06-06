class Reflection : Activity{
    private List<string> _promptList = new List<string>();
    private List<string> _questionList = new List<string>();
    //used for keeping track of used indexes for random
    private List<int> _indexList = new List<int>();
    private string _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    public Reflection(string name) : base(name){
        base.SetDescription(_description);
        BuildPromptList();
        BuildQuestionList();
    }

    public void RunReflectionActivity(){
        //display start message and run basic get ready animation
        base.DisplayStartMsg();
        Console.Clear();
        base.PauseAnimation(base._pause, "spin", "Get ready...");
        Console.Clear();

        //display prompt and wait for user to hit enter.  Then prep user for upcoming questions and give countdown timer.
        DisplayPrompt();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        base.PauseAnimation(base._pause,"countdown", "You may begin in: ");
        Console.Clear();
        
        //While duration limit not met, keep providing random questions using pingpong animation
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base._duration);
        while (DateTime.Now < endTime){
            DisplayQuestion();
            base.PauseAnimation(base._pause,"pingpong", "");
            Console.Write("\n");
        }
        //standard end message
        base.DisplayEndMsg();
    }

    //writes out the prompt question
    private void DisplayPrompt(){
        Console.WriteLine("Consider the following prompt:");
        //calling it directly
        Console.WriteLine(_promptList[GenerateRandomIndex(_promptList)]+"\n");
    }

    //used to display random questions
    private void DisplayQuestion(){
        int newIndex = GenerateRandomIndex(_questionList);
        //EXTRA to keep from repeating random questions
        //if it's one that's already been used it'll be in the indexList, so we skip and try again
        while (_indexList.Contains(newIndex)){
            //if it's in it, then loop until we can an index that isn't in the list
            //First were going to check if the count of the _indexList is the same as the _questionList.  If so that means we've gone through all of the questions.  In this case, we'll reset the _indexList so we can work through them again.  
            if (_indexList.Count() == _questionList.Count){
                _indexList.Clear();
            }
            else{
                newIndex = GenerateRandomIndex(_questionList);
            }
            
        }
        //if it's not in the list already, then add it, then write it out
        _indexList.Add(newIndex);
        Console.Write(_questionList[newIndex]);
        //Console.Write(_questionList[GenerateRandomIndex(_questionList)]);
    }


    private void BuildPromptList(){
        _promptList.Add("---Think of a time when you stood up for someone else.---");
        _promptList.Add("---Think of a time when you did something really difficult.---");
        _promptList.Add("---Think of a time when you helped someone in need.---");
        _promptList.Add("---Think of a time when you did something truly selfless.---");
    }
    private void BuildQuestionList(){
        _questionList.Add(">Why was this experience meaningful to you?");
        _questionList.Add(">Have you ever done anything like this before?");
        _questionList.Add(">How did you get started?");
        _questionList.Add(">How did you feel when it was complete?");
        _questionList.Add(">What made this time different than other times when you were not as successful?");
        _questionList.Add(">What is your favorite thing about this experience?");
        _questionList.Add(">What could you learn from this experience that applies to other situations?");
        _questionList.Add(">What did you learn about yourself through this experience?");
        _questionList.Add(">How can you keep this experience in mind in the future?");
    }

    //simply random index generator.  
    private int GenerateRandomIndex(List<string> alist){
        int length = alist.Count();
        Random r = new Random();
        int randomIndex = r.Next(length);
        return randomIndex;
    }
}