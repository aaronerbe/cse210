public class EternalGoal: Goal{
    //Create Rewards Class to track rewards
    private  Rewards r = new Rewards(2);
    private string _reward = "";

    public EternalGoal(bool isNew):base(isNew){
        //using -1 to indicate it never ends.  Or max number of times to complete it is infinite
        base.SetNumMax(-1);
    }

    public override string RecordEvent(){
        base.SetNumDone(1);
        //capture the reward.  If a reward was earned it won't be an empty string.  else it'll be ""
        _reward = r.TrackReward();
        return _reward;
    }

    public string CheckReward(){
        return _reward;
    }

    public override string GetXofYSummary()
    {
        return "";
    }

    //EXTRA:  Add infinity symbol for eternal goals
    public override string GetCheckBox(){
        return "\u221E";
    }
}