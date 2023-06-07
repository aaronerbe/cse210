public class SimpleGoal : Goal{
    
    public SimpleGoal(string goal, string description, int points) : base(goal, description, points){
        base.SetNumMax(1);
    }

    public override void RecordEvent(){
        base.SetComplete();
        base.SetNumDone(1);
    }

    public override int GetTotalPoints(){
        return base.GetPoints() * base.GetNumDone();
    }
}