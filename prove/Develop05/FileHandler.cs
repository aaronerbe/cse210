class FileHandler {
    private string _goalsFilePath;
    private string _rewardsFilePath;
    //main program passes this on for us to write to file so it's accessible when we read it back
    private int _totalPoints;
    //use List<Goal> and List<Rewards> here so we can simply pass on the list in the constructor
    private List<Goal> _goalList = new List<Goal>();
    private List<Rewards> _rewardsList = new List<Rewards>();
    //set delimiter as variable so it can easily be modified later if needed.
    private string _csvDelimiter = "~~";
    //The Goal Classes expect a bool (new) for an input so they know if it's a newly created goal from user, or if it's a goal being read in from file.  Those classes have to handle setup slightly differently
    private bool _new = false;

    public FileHandler(string goalsFilePath, string rewardsFilePath,List<Rewards> rewardsList, List<Goal> goalList, int totalPoints){
        _goalsFilePath = goalsFilePath;
        _rewardsFilePath = rewardsFilePath;
        _rewardsList = rewardsList;
        _goalList = goalList;
        _totalPoints = totalPoints;
    }

    public void WriteRewards(){
        //temp line to be written to file
        string line = "";
        //false overwrites existing info in the file.  it does not append to the file
        using (StreamWriter writer = new StreamWriter(_rewardsFilePath,false)){
            //step through all rewards in the list passed on from main
            foreach (Rewards r in _rewardsList){
                //capture the rewards they've earned for this type of goal (simple, eternal or checklist)
                List<string> rewards = new List<string>();
                rewards = r.GetRewards();
                //grab the count of goals they've completed towards the next reward
                int goalsCount = r.GetGoalsCounter();
                //append the beginning info needed (goalname, goals count)to the line we will use to save to file.  
                line = $"{r.GetType().Name}~~{goalsCount}";
                //grab the actual rewards earned and append each of them to the line
                for (int i = 1; i<rewards.Count;i++){
                    line += $"~~{rewards[i]}";
                }
                writer.WriteLine(line);
            }
        }
    }

    public List<Rewards> ReadRewards(){
    //create a list for each type of reward
    _rewardsList.Add(new SimpleRewards(5));
    _rewardsList.Add(new EternalRewards(5));
    _rewardsList.Add(new ChecklistRewards(5));
    
    using (StreamReader reader = new StreamReader(_rewardsFilePath)){
        string line;
        //create a list to hold each delimited item in the line
        string[] lineList;    
        //step through the file line by line till we hit the end
        while ((line = reader.ReadLine()) != null){
            //delimit and add to the list
            lineList = line.Split(_csvDelimiter);
            //step through each reward class instance in the list
            foreach (Rewards r in _rewardsList){
                //used to only create a new instance of the class if it's the right class (matches lineList[0] which is the name of the Reward)
                if (lineList[0] == r.GetType().Name){
                    //set the info for that class
                    r.SetGoalsCounter(int.Parse(lineList[1]));
                    // has to be -3 to remove the two other entries in the CSV (the goal type and the count of goals achieved towards a reward) - 1 more to align with the 0 index of the _rewards list (starts w/ 0, not 1)
                    r.SetRewardsEarned(lineList.Count()-3);
                }
            }
        }
    }
    return _rewardsList;
}

    public void WriteGoals(){
        string line = "";

        using (StreamWriter writer = new StreamWriter(_goalsFilePath)){
            //write the total points to line so we can keep track
            writer.WriteLine(_totalPoints);
            //step through each goal in the goalList
            foreach (Goal g in _goalList){
                //not a fan of it being hardcoded but couldn't think of a better way.  
                //for each type of goal, the info saved off is slighly different (e.g. checklist has bonus, numMax, numDone)
                switch (g.GetType().Name){
                    case "SimpleGoal":
                        line = $"{g.GetType().Name}~~{g.GetGoal()}~~{g.GetDescription()}~~{g.GetPoints()}~~{g.GetComplete()}"; 
                        break;
                    case "EternalGoal":
                        line = $"{g.GetType().Name}~~{g.GetGoal()}~~{g.GetDescription()}~~{g.GetPoints()}"; 
                        break;
                    case "ChecklistGoal":
                        line = $"{g.GetType().Name}~~{g.GetGoal()}~~{g.GetDescription()}~~{g.GetPoints()}~~{g.GetBonus()}~~{g.GetNumMax()}~~{g.GetNumDone()}"; 
                        break;
                }
                writer.WriteLine(line);
            }
        } 
    }



    public List<Goal> ReadGoals(){
        //_new = false tells the goal it's not a new goal but an existing one we read in from a file...
        using (StreamReader reader = new StreamReader(_goalsFilePath)){
            //read the first line which only contains the total points earned (from all goals)
            string line = reader.ReadLine();
            //split the line by delimiter and save to the list
            string[] lineList = line.Split(_csvDelimiter);
            //grab points
            _totalPoints = int.Parse(lineList[0]);
            
            //now loop through the rest doing the same
            while ((line = reader.ReadLine()) != null){
                lineList = line.Split(_csvDelimiter);
                //actions slightly different depending on the goal type.  E.g. no need to set bonus info for Simple Goal
                switch (lineList[0]){
                    case "SimpleGoal":
                        //create new Goal instance, set the attributes and then add it to the _goalList
                        SimpleGoal s = new SimpleGoal(_new);
                        s.SetGoal(lineList[1]);
                        s.SetDescription(lineList[2]);
                        s.SetPoints(int.Parse(lineList[3]));
                        s.SetComplete(bool.Parse(lineList[4]));
                        _goalList.Add(s);
                        break;
                    case "EternalGoal":
                        EternalGoal e = new EternalGoal(_new);
                        e.SetGoal(lineList[1]);
                        e.SetDescription(lineList[2]);
                        e.SetPoints(int.Parse(lineList[3]));
                        _goalList.Add(e);
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal c = new ChecklistGoal(_new);
                        c.SetGoal(lineList[1]);
                        c.SetDescription(lineList[2]);
                        c.SetPoints(int.Parse(lineList[3]));
                        c.SetBonusPoints(int.Parse(lineList[4]));
                        c.SetNumMax(int.Parse(lineList[5]));
                        c.SetNumDone(int.Parse(lineList[6]));
                        //c.SetComplete(bool.Parse(lineList[4]));
                        _goalList.Add(c);
                        break;
                }
            }
        }
        //return our newly build _goalList which is a list of goals List<Goal>
        return _goalList;
    }

    public int GetTotalPoints(){
        //returns total points for display
        return _totalPoints;
    }
}