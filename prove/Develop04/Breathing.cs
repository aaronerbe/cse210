class Breathing : Activity{
    private string _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

    //pass name directly to parent and set the description text
    public Breathing(string name) : base(name){
        //base.SetName(name);
        base.SetDescription(_description);
    }

    public void RunBreatheActivity(){
        //Display standard starting message, pause animation to prep them, then breathing animation for duration, then standard end msg
        base.DisplayStartMsg();
        Console.Clear();
        base.PauseAnimation(base._pause,"spin", "Get ready...");
        base.PauseAnimation(base._duration, "breathe", "");
        Console.Clear();
        base.DisplayEndMsg();
    }
}