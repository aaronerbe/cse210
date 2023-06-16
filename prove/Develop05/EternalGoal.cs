public class EternalGoal: Goal{

    public EternalGoal(bool isNew):base(isNew){
        //using -1 to indicate it never ends.  Or max number of times to complete it is infinite
        //if this was 1, it would compelte as soon as they completed 1 time (e.g. simple goal)
        //Since it's eternal, I set to -1 so it's clear it never completes.  
        base.SetNumMax(-1);
    }

    public override void RecordEvent(){
        base.SetNumDone(1);
        //capture the reward.  If a reward was earned it won't be an empty string.  else it'll be ""
    }

    public override string GetXofYSummary()
    {
        //not used for eternal so setting to empty
        return "";
    }

    //EXTRA:  Add infinity symbol for eternal goals
    public override string GetCheckBox(){
        //unique to eternal
        return "\u221E";
    }
}