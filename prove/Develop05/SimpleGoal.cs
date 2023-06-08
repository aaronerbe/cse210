public class SimpleGoal : Goal{
    public SimpleGoal(){
        base.SetNumMax(1);
    }

    public override void RecordEvent(){
        base.SetComplete(true);
        base.SetNumDone(1);
    }

    //public override int GetTotalPoints(){
    //    return base.GetPoints() * base.GetNumDone();
    //}
    public override string GetXofYSummary()
    {
        return "";
    }
}