public abstract class Goal{
    private string _goal;
    private string _description;
    private bool _complete = false;
    private int _points = 0;
    private int _bonusPoints = 0;
    private int _numDone = 0;
    private int _numMax = 0;

    public Goal(){
        //Console.Clear();
        //Console.WriteLine("What is the name of your goal?  ");
        //_goal = Console.ReadLine();
        //Console.WriteLine("What is a short description of it?  ");
        //_description = Console.ReadLine();
        //Console.WriteLine("What is the amount of points associated with this goal?  ");
        //_points = int.Parse(Console.ReadLine());
    }

    //OVERRIDES
    public abstract void RecordEvent();
    //public abstract int GetTotalPoints();
    public abstract string GetXofYSummary();
    //return an X to mark it as complete
    public virtual string GetCheckBox(){
        if (_complete){
            return "X";
        }
        else{
            return " ";
        }
    }

    //GETTERS
    public bool GetComplete(){
        return _complete;
    }
    public string GetGoal(){
        return _goal;
    }
    public string GetDescription(){
        return _description;
    }
    public virtual int GetPoints(){
        return _points;
    }
    public int GetBonus(){
        return _bonusPoints;
    }
    public int GetNumDone(){
        return _numDone;
    }
    public int GetNumMax(){
        return _numMax;
    }

    //SETTERS
    public void SetBonusPoints(int bonusPoints){
        _bonusPoints = bonusPoints;
    }
    public void SetGoal(string goal){
        _goal = goal;
    }
    public void SetDescription(string description){
        _description = description;
    }
    public void SetPoints(int points){
        _points = points;
    }
    public void SetComplete(bool isComplete){
        if (isComplete){
            _complete = true;
        }
        else{
            _complete = false;
        }
    }
    public void SetNumDone(int numDone){
        _numDone += numDone;
    }
    public void SetNumMax(int numMax){
        _numMax = numMax;
    }
}