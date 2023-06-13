//TODO  group the goals by type
//TODO capture the awards earned by type as well?

class FileHandler {
    private string _filepath;
    private int _totalPoints;
    private List<Goal> _goalList = new List<Goal>();
    private string _csvDelimiter = "~~";
    private bool _new = false;

    public FileHandler(string filepath, List<Goal> goalList, int totalPoints){
        _filepath = filepath;
        _goalList = goalList;
        _totalPoints = totalPoints;
    }

    public void WriteGoals(){
        string line = "";

        using (StreamWriter writer = new StreamWriter(_filepath)){
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
        using (StreamReader reader = new StreamReader(_filepath)){
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