public class ChecklistGoal: Goal{
    private int _bonusPoints;
    private int _numberToBonus;

    public ChecklistGoal(string goal, string description, int points, int numberToBonus, int bonusPoints) : base(goal, description, points){
        _numberToBonus = numberToBonus;
        _bonusPoints = bonusPoints;
        base.SetNumMax(_numberToBonus);
    }

    public override void RecordEvent()
    {
        base.SetNumDone(1);
        // if number done is >= to number to get bonus, then set goal to complete
        if (base.GetNumDone() >= _numberToBonus){
            base.SetComplete();
        }
    }

    public override int GetTotalPoints(){
        //check if numdone >= max or 'numberToBonus' if it is, give the bonus.
        if (base.GetNumDone() >= _numberToBonus){
            return base.GetPoints() * base.GetNumDone() + _bonusPoints;
        }
        else{
            return base.GetPoints() * base.GetNumDone();
        }
        
    }
}