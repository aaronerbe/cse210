public class SimpleGoal : Goal{

    public SimpleGoal(bool isNew): base(isNew){
        //set to 1.  meaning as soon as they get 1 done, it's complete.  
        base.SetNumMax(1);
    }

    public override void RecordEvent(){
        //simply set to complete and add it to the base class
        base.SetComplete(true);
        base.SetNumDone(1);
    }
    
    public override string GetXofYSummary()
    {
        //return empty since this is only used for checklist type.  
        return "";
    }
}