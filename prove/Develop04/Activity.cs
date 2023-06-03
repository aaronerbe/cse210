class Activity{
    private string _activityName;
    private string _activityDescription;
    protected int _duration;
    private int _pause = 5;
    private Animation a = new Animation();

    //private string _startMsg;
    //private string _endMsg;

    public Activity (string name){
        _activityName = name;
        //_activityDescription = description;
        _duration = 30;
        //get description based on name
        GenerateDescription();

    }
    public void DisplayStartMsg(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity.\n\n{_activityDescription}\n");
        Console.WriteLine("How long, in seconds, would you like your session?");
        _duration = (int.Parse(Console.ReadLine()));
    }
    public void DisplayEndMsg(){
        //Console.Clear();
        //Console.WriteLine("\n")
        Console.WriteLine("\nWell done!!\n");
        a.RunAnimation(_pause, "spin");
        Console.WriteLine($"You've completed another {_duration} seconds of the {_activityName} activity.");
        a.RunAnimation(_pause, "spin");
    }
    //Can handle automation or countdowns by type.  
    public void PauseAnimation(int duration, string type){
        a.RunAnimation(duration,type);
    }
    //public int GetDuration(){
    //    return _duration;
    //}
    //public void SetName(string name){
    //    _activityName = name;
    //}

    private void GenerateDescription(){
        string breathDescription = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        string reflectionDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        string listingDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        switch (_activityName.ToLower()){
            case "breathing":
                _activityDescription = breathDescription;
                break;
            case "reflection":
                _activityDescription = reflectionDescription;
                break;
            case "listing":
                _activityDescription = listingDescription;
                break;
        }
    }
}