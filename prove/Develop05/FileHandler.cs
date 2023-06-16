class FileHandler {
    private string _goalsFilePath;
    private string _rewardsFilePath;
    private int _totalPoints;
    private List<Goal> _goalList = new List<Goal>();
    private List<Rewards> _rewardsList = new List<Rewards>();
    private string _csvDelimiter = "~~";
    private bool _new = false;

    public FileHandler(string goalsFilePath, string rewardsFilePath,List<Rewards> rewardsList, List<Goal> goalList, int totalPoints){
        _goalsFilePath = goalsFilePath;
        _rewardsFilePath = rewardsFilePath;
        _rewardsList = rewardsList;
        _goalList = goalList;
        _totalPoints = totalPoints;
    }

    public void WriteRewards(){
        string line = "";
        using (StreamWriter writer = new StreamWriter(_rewardsFilePath,false)){
            foreach (Rewards r in _rewardsList){
                List<string> rewards = new List<string>();
                rewards = r.GetRewards();
                int goalsCount = r.GetGoalsCounter();

                line = $"{r.GetType().Name}~~{goalsCount}";
                
                for (int i = 1; i<rewards.Count;i++){
                    line += $"~~{rewards[i]}";
                }
                //line = $"{r.GetType().Name}~~{r.GetRewards()}";
                writer.WriteLine(line);
            }
        }
    }

    public List<Rewards> ReadRewards(){
        //TODO I should pass the numbers to filehandler? for now just setting to match what I hard coded in program
    _rewardsList.Add(new SimpleRewards(5));
    _rewardsList.Add(new EternalRewards(5));
    _rewardsList.Add(new ChecklistRewards(5));
    
    using (StreamReader reader = new StreamReader(_rewardsFilePath)){
        string line;
        string[] lineList;    
        while ((line = reader.ReadLine()) != null){
            lineList = line.Split(_csvDelimiter);

            foreach (Rewards r in _rewardsList){
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
            writer.WriteLine(_totalPoints);

            foreach (Goal g in _goalList){
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
        //tells the goal it's not a new goal but an existing one we read in from a file...
        using (StreamReader reader = new StreamReader(_goalsFilePath)){
            string line = reader.ReadLine();
            string[] lineList = line.Split(_csvDelimiter);
            _totalPoints = int.Parse(lineList[0]);
            
            while ((line = reader.ReadLine()) != null){
                
                lineList = line.Split(_csvDelimiter);
                
                switch (lineList[0]){
                    case "SimpleGoal":
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
                        //e.SetComplete(bool.Parse(lineList[4]));
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
        return _goalList;
    }

    public int GetTotalPoints(){
        return _totalPoints;
    }
}