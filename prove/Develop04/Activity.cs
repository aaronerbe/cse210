class Activity{
    private string _activityName;
    private string _activityDescription;
    //length of time to run each activity
    protected int _duration;
    //length of time to pause for animations
    protected int _pause = 5;
    //create instance of the animation
    private Animation a = new Animation();

    public Activity (string name){
        _activityName = name;
        _duration = 30;
    }

    //The standard Start Message for each activity.  This is where user provides duration for each activity
    public void DisplayStartMsg(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity.\n\n{_activityDescription}\n");
        Console.Write("How long, in seconds, would you like your session?  ");
        _duration = (int.Parse(Console.ReadLine()));
    }

    //Standard end message with some basic animations and summary
    public void DisplayEndMsg(){
        Console.CursorVisible =false;
        //Console.WriteLine("Well done!!\n");
        a.RunAnimation(_pause, "spin", "Well done!!");
        //Console.WriteLine($"You've completed another {_duration} seconds of the {_activityName} activity.");
        a.RunAnimation(_pause, "spin", $"You've completed another {_duration} seconds of the {_activityName} activity.");
        Console.CursorVisible = true;
    }
    
    //Pause Animation
    //Can handle automation or countdowns by type using keywords.  
    public void PauseAnimation(int duration, string type, string msg){
        a.RunAnimation(duration,type, msg);
    }

    //Used to set the description of each activity.  The description string is owned by each subclass and passed onto the parent (Activity).
    public void SetDescription(string description){
        _activityDescription = description;
    }

//Moved to each sub class owning it's own description and passing it into the Activity parent class.  This way as new classes are created, Activity class doesn't need updated.  
    //private void GenerateDescription(){
    //    string breatheDescription = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    //    string reflectionDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    //    string listingDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    //    switch (_activityName.ToLower()){
    //        case "breathing":
    //            _activityDescription = breatheDescription;
    //            break;
    //        case "reflection":
    //            _activityDescription = reflectionDescription;
    //            break;
    //        case "listing":
    //            _activityDescription = listingDescription;
    //            break;
    //    }
    //}
}