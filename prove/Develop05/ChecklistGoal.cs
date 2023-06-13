//TODO change [0] to just be [ ] until at least 1 goal has been achieved.  then do [1]
public class ChecklistGoal: Goal{
    private Rewards _rewards = new Rewards(5);
    //private string _reward = "";
    
    public ChecklistGoal(bool isNew):base(isNew){
        //use isNew to determine if we need to ask questions (to build a new goal) or if we are reading from a file (existing goal)

        if (isNew){
            Console.WriteLine ("How many times does this goal need to be accomplished for a bonus?  ");
            base.SetNumMax(int.Parse(Console.ReadLine()));
            Console.WriteLine("What is the bonus for accomplishing it that many times?  ");
            base.SetBonusPoints(int.Parse(Console.ReadLine()));
        }
    }

    public override string RecordEvent()
    {
        base.SetNumDone(1);
        // if number done is >= to number to get bonus, then set goal to complete
        if (base.GetNumDone() >= base.GetNumMax()){
            base.SetComplete(true);
        }
        //capture the reward.  If a reward was earned it won't be an empty string.  else it'll be ""
        //_reward = r.TrackReward();
        //return _reward;
        return _rewards.TrackReward();
    }
    public override int GetPoints(){
        //if (base.GetNumDone() >= _numberToBonus){
        if (base.GetNumDone() >= base.GetNumMax()){
            return base.GetPoints() + base.GetBonus();
        }
        else{
            return base.GetPoints();
        }
    }

    public override string GetXofYSummary()
    {
        return $" -- Currently completed: {base.GetNumDone()}|{base.GetNumMax()}";
    }

    //EXTRA:  Add number done in the checkbox for clarity
    public override string GetCheckBox(){
        return base.GetNumDone().ToString();
    }
}