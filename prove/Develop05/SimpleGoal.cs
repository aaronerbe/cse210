public class SimpleGoal : Goal{
    private Rewards _rewards = new Rewards(5);
    //private string _reward = "";

    public SimpleGoal(bool isNew): base(isNew){
        base.SetNumMax(1);
    }

    public override string RecordEvent(){
        base.SetComplete(true);
        base.SetNumDone(1);
        //capture the reward.  If a reward was earned it won't be an empty string.  else it'll be ""
        //_reward = r.TrackReward();
        //return _reward;
        return _rewards.TrackReward();
    }
    
    public override string GetXofYSummary()
    {
        return "";
    }
}