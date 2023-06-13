using System;
//TODO:  Work on Extras...
//TODO - catch if trying to record and no goals exist
//TODO - stop awards when full count
//TODO - catch cases of invalid inputs, etc
//TODO - Comments
//!EXTRA - checkbox is a little clearer.  Infitinity symbol for eternal goals.  x from X|Y in the checklist goal.  
//!EXTRA - Reward badges given for doing x number of achivements for a given goal.  
//TODO - figure out if below functiosn need static or private or public or left alone...

class Program
{
    static void Main(string[] args)
    {
        //used to create a rewards class for each goal type (simple, eternal, checklist)
        //seting up as a list so I can simply loop through it when recording.  I may regret this later?
        List<Rewards> rewardsList = new List<Rewards>(){
            new SimpleRewards(5),
            new EternalRewards (5),
            new ChecklistRewards(5)
        };
        

        //used to decide if we are creating a new goal or reading it in.
        bool isNew = true;
        List<Goal> goalsList = new List<Goal>();
        int totalPoints = 0;
        string goalFilename = "goals.txt";
        string rewardsFilename = "rewards.txt";

        MainMenu MainMenu = new MainMenu();
        Console.Clear();
        Console.WriteLine($"You have {totalPoints} points.\n");
        int userMainEntry = MainMenu.DisplayMenu();

        while (userMainEntry != 7){
            switch (userMainEntry){
                case 1:
                    GoalMenu GoalsMenu = new GoalMenu ();
                    Console.Clear();
                    int userSubEntry = GoalsMenu.DisplayMenu();
                    switch (userSubEntry){
                        case 1:
                            SimpleGoal s = new SimpleGoal(isNew);
                            //GetGoalInputs(s);
                            goalsList.Add(s);
                            break;
                        case 2:
                            //Eternal Goal
                            EternalGoal e = new EternalGoal(isNew);
                            //GetGoalInputs(e);
                            goalsList.Add(e);
                            break;
                        case 3: 
                            //Checklist Goal
                            ChecklistGoal c = new ChecklistGoal(isNew);
                            //GetGoalInputs(c);
                            goalsList.Add(c);
                            break;
                    }
                    break;
                case 2:
                    //list goals
                    DisplayFullGoals(goalsList);
                    break;
                case 3:
                    //list rewards
                        DisplayRewards(rewardsList);
                    break;
                case 4:
                    //save goals
                    //TODO - add save rewards at same time
                    FileHandler fWrite = new FileHandler(goalFilename, rewardsFilename,rewardsList, goalsList, totalPoints);
                    fWrite.WriteGoals();
                    fWrite.WriteRewards();
                    break;
                case 5:
                    //Load goals
                    FileHandler fRead = new FileHandler(goalFilename, rewardsFilename,rewardsList, goalsList, totalPoints);
                    goalsList.Clear();
                    goalsList = fRead.ReadGoals();
                    totalPoints = fRead.GetTotalPoints();
                    //read in rewards and then pass to rebuildrewards so we can assign all the info to the classes...
                    rewardsList.Clear();
                    rewardsList=fRead.ReadRewards();
                    break;
                case 6:
                    //record event
                    DisplayGoals(goalsList);
                    Console.Write("Which goal did you accomplish? ");
                    userSubEntry = int.Parse(Console.ReadLine()) -1;
                    totalPoints += RecordGoal(userSubEntry, goalsList, totalPoints);
                    break;
            }
            Console.Clear();
            Console.WriteLine($"You have {totalPoints} points.\n");
            userMainEntry = MainMenu.DisplayMenu();
        }

        static void DisplayRewards(List<Rewards> rewardsList){
            Console.Clear();
            foreach(Rewards r in rewardsList){
                
                string line = ($"{r.GetType().Name}:\n    ");
                //string line = "";

                List<string> rewardsString = new List<string>(r.GetRewards());
                for(int i = 1; i<rewardsString.Count(); i++){
                    line += $"{rewardsString[i]}, ";
                }
                
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPress Enter to Continue: ");
            Console.ReadLine();
        }

        //lists everything about the goal
        static void DisplayFullGoals(List<Goal> goalsList){
            Console.Clear();
            int i = 1;
            foreach(Goal g in goalsList){
                Console.WriteLine($"{i}.  [{g.GetCheckBox()}] {g.GetGoal()} ({g.GetDescription()}){g.GetXofYSummary()}");
                i++;
            }
            Console.Write("Press Enter to return to Main Menu:  ");
            Console.ReadLine();
        }

        //Displays just the goals user has created.  Not all the extra info like points, etc.  It's so user can select which goal to record an event for.  
        static void DisplayGoals(List<Goal> goalsList){
            Console.Clear();
            int i = 1;
            foreach(Goal g in goalsList){
                Console.WriteLine($"{i}.  [{g.GetCheckBox()}] {g.GetGoal()}");
                i++;
            }
        }

        int RecordGoal(int entry, List<Goal> goalsList, int totalPoints){
            int pointsEarned = 0;
            goalsList[entry].RecordEvent();
            //get points earned
            pointsEarned = goalsList[entry].GetPoints();
            Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points.");
            Console.WriteLine($"You now have {pointsEarned + totalPoints} points.\n");
            
            RecordReward(goalsList[entry].GetType().Name);

            Console.WriteLine("Press Enter to return to Main Menu:  ");
            Console.ReadLine();
            return pointsEarned;
        }

        void RecordReward(string goal){
            string reward = "";
            //Console.WriteLine($"goal is {goal}");
            foreach(Rewards r in rewardsList){
                //Console.WriteLine(r.GetType().Name);
                if (r.GetType().Name.Contains(goal.Substring(0,5))){
                    reward = r.TrackReward();
                }
            }
            //check if reward is an empty string.  If it's not that means they earned a reward.  Display it to the screen.  
            if (!string.IsNullOrEmpty(reward)){
                Console.WriteLine($"\n\nCongratulations!  You've earned {goal}: {reward}.  Keep Up the Good work!\n\n");
            }
        }
    }
}