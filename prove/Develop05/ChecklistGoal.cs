public class ChecklistGoal: Goal{
    //private int _bonusPoints;
    //private int _numberToBonus;

    //public ChecklistGoal(string goal, string description, int points, int numberToBonus, int bonusPoints) : base(goal, description, points){
    //    _numberToBonus = numberToBonus;
    //    _bonusPoints = bonusPoints;
    //    base.SetNumMax(_numberToBonus);
    //}

    public ChecklistGoal(){
        //Console.WriteLine ("How many times does this goal need to be accomplished for a bonus?  ");
        //_numberToBonus = int.Parse(Console.ReadLine());
        //Console.WriteLine("What is the bonus for accomplishing it that many times?  ");
        ////_bonusPoints = int.Parse(Console.ReadLine());
        //base.SetBonusPoints(int.Parse(Console.ReadLine()));
        //base.SetNumMax(_numberToBonus);
    }

    public override void RecordEvent()
    {
        base.SetNumDone(1);
        // if number done is >= to number to get bonus, then set goal to complete
        //if (base.GetNumDone() >= _numberToBonus){
            if (base.GetNumDone() >= base.GetNumMax()){
            base.SetComplete(true);
        }
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

    //public override int GetTotalPoints(){
    //    //check if numdone >= max or 'numberToBonus' if it is, give the bonus.
    //    //if (base.GetNumDone() >= _numberToBonus){
    //    if (base.GetNumDone() >= base.GetNumMax()){
    //        return base.GetPoints() * base.GetNumDone() + base.GetBonus();
    //    }
    //    else{
    //        return base.GetPoints() * base.GetNumDone();
    //    } 
    //}
    public override string GetXofYSummary()
    {
        return $" -- Currently completed: {base.GetNumDone()}|{base.GetNumMax()}";
    }

    //EXTRA:  Add number done in the checkbox for clarity
    public override string GetCheckBox(){
        return base.GetNumDone().ToString();
    }
}