public class EternalGoal: Goal{

    public EternalGoal(){
        //using -1 to indicate it never ends.  Or max number of times to complete it is infinite
        base.SetNumMax(-1);
    }

    public override void RecordEvent(){
        base.SetNumDone(1);
    }
    //public override int GetTotalPoints(){
    //    return base.GetPoints() * base.GetNumDone();
    //}

    public override string GetXofYSummary()
    {
        return "";
    }

    //EXTRA:  Add infinity symbol for eternal goals
    public override string GetCheckBox(){
        return "\u221E";
    }
}