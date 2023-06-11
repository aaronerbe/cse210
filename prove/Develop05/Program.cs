using System;
//TODO:  Work on Extras...
//TODO - add a way to display rewards earned
//TODO - add rewards to the saved file & a way to read in and re-add them to the goal class
//TODO - catch if trying to record and no goals exist
//TODO - what to do about Simple goal rewards.  perhaps not do it and only do rewards for eternal goals?
//!EXTRA - checkbox is a little clearer.  Infitinity symbol for eternal goals.  x from X|Y in the checklist goal.  
//!EXTRA - Reward badges given for doing x number of achivements for a given goal.  


class Program
{
    static void Main(string[] args)
    {
        //used to decide if we are creating a new goal or reading it in.
        bool isNew = true;
        List<Goal> goalsList = new List<Goal>();
        int totalPoints = 0;
        string filename = "goals.txt";

        MainMenu MainMenu = new MainMenu();
        Console.Clear();
        Console.WriteLine($"You have {totalPoints} points.\n");
        int userMainEntry = MainMenu.DisplayMenu();

        while (userMainEntry != 6){
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
                    //save goals
                    FileHandler fWrite = new FileHandler(filename, goalsList, totalPoints);
                    fWrite.WriteFile();
                    break;
                case 4:
                    //Load goals
                    FileHandler fRead = new FileHandler(filename, goalsList, totalPoints);
                    goalsList.Clear();
                    goalsList = fRead.ReadFile();
                    totalPoints = fRead.GetTotalPoints();
                    break;
                case 5:
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

        static int RecordGoal(int entry, List<Goal> goalsList, int totalPoints){
            int pointsEarned = 0;
            string reward = goalsList[entry].RecordEvent();
            //get points earned
            pointsEarned = goalsList[entry].GetPoints();
            Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points.");
            Console.WriteLine($"You now have {pointsEarned + totalPoints} points.\n");
            
            //check if reward is an empty string.  If it's not that means they earned a reward.  Display it to the screen.  
            if (reward != ""){
                Console.WriteLine($"\n\nCongratulations!  You've earned {goalsList[entry].GetType().Name} {reward}.  Keep Up the Good work!\n\n");
            }

            Console.WriteLine("Press Enter to return to Main Menu:  ");
            Console.ReadLine();
            return pointsEarned;
        }
    }
}