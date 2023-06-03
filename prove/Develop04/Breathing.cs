class Breathing : Activity{
    //hardcoded breathing time    
    int _breathInTime = 5;
    int _breathOutTime = 5;

    public Breathing(string name) : base(name){
        //base.SetName(name);
    }

    public void RunBreathActivity(){
        base.DisplayStartMsg();
        base.PauseAnimation(base._duration, "grow");
        base.DisplayEndMsg();
    }


}