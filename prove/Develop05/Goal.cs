public abstract class Goal{
    private string _goal;
    private string _description;
    private bool _complete = false;
    private int _points = 0;
    private int _numDone = 0;
    private int _numMax = 0;

    public Goal(string goal, string description, int points){
        _goal = goal;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract int GetTotalPoints();

    //Getters
    public bool IsComplete(){
        return _complete;
    }
    public string GetGoal(){
        return _goal;
    }
    public int GetPoints(){
        return _points;
    }
    public int GetNumDone(){
        return _numDone;
    }
    public int GetNumMax(){
        return _numMax;
    }

    //Setters
    public void SetGoal(string goal){
        _goal = goal;
    }
    public void SetDescription(string description){
        _description = description;
    }
    public void SetComplete(){
        _complete = true;
    }
    public void SetNumDone(int numDone){
        _numDone += numDone;
    }
    public void SetNumMax(int numMax){
        _numMax = numMax;
    }
    //public void SetPoints(int points){
    //}



}