public abstract class Goal{
    //goal name
    private string _goal;
    //goal description
    private string _description;
    //tracks if the goal has been completed.  used to display checkmarks if applicable
    private bool _complete = false;
    //how many points the goal is worth
    private int _points = 0;
    //how many bonus points user recieves if number of completions meets the max criteria
    private int _bonusPoints = 0;
    //tracks how many times they've compelted the goal (used for checklist)
    private int _numDone = 0;
    //sets the trigger to determine if they've completed the goal
    private int _numMax = 0;
    //used to decide if it's a new goal or one read in from file (decides if we need to ask user questions or not)
    private bool _isNew;

    public Goal(bool isNew){
        _isNew = isNew;
        //using _isNew as a trigger to determine if the goal has been created before or if we are reading an existing in from a file (which means we don't need to ask user for all the info, just reset all the attributes)
        if (_isNew){
            Console.Clear();
            Console.WriteLine("What is the name of your goal?  ");
            _goal = Console.ReadLine();
            Console.WriteLine("What is a short description of it?  ");
            _description = Console.ReadLine();
            //loop until user gives valid integer for input
            Console.WriteLine("What is the amount of points associated with this goal?  ");
            //_points = int.Parse(Console.ReadLine());
            //check if it can parse to integer, if not (false), loop till they get it right
            while (!int.TryParse(Console.ReadLine(),out _points)){
                Console.Clear();
                Console.WriteLine("Please enter a valid number.\nWhat is the amount of points associated with this goal?  ");
            }
        }
    }

    //OVERRIDES
    //each child class records things slightly differently.  
    public abstract void RecordEvent();
    //child class handles diff.  E.g. Simple doesn't keep track of x complete out of y times to signoff the goal
    public abstract string GetXofYSummary();
    public virtual string GetCheckBox(){
        //return an X to mark it as complete
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