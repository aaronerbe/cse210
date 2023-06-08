using System;
//TODO:  Work on Extras...

class Program
{
    static void Main(string[] args)
    {
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
                            SimpleGoal s = new SimpleGoal();
                            GetGoalInputs(s);
                            goalsList.Add(s);
                            break;
                        case 2:
                            //Eternal Goal
                            EternalGoal e = new EternalGoal();
                            GetGoalInputs(e);
                            goalsList.Add(e);
                            break;
                        case 3: 
                            //Checklist Goal
                            ChecklistGoal c = new ChecklistGoal();
                            GetGoalInputs(c);
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

        static void DisplayFullGoals(List<Goal> goalsList){
            Console.Clear();
            int i = 1;
            foreach(Goal g in goalsList){
                Console.WriteLine($"{i}.  [{g.GetCheckBox()}] {g.GetGoal()} ({g.GetDescription()}){g.GetXofYSummary()}");
                i++;
            }
            Console.WriteLine("Press Enter to return to Main Menu:  ");
            Console.ReadLine();
        }

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
            goalsList[entry].RecordEvent();
            //get points earned
            pointsEarned = goalsList[entry].GetPoints();
            Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points.");

            Console.WriteLine($"You now have {pointsEarned + totalPoints} points.\n");

            Console.WriteLine("Press Enter to return to Main Menu:  ");
            Console.ReadLine();
            return pointsEarned;
        }

        //Get goal inputs from user.  Used to be handled inside the class but that prevented me from adding the goals classes into a list when reading in as that would redo all the questions instead of allowing me to just read them in and set them.  
        static void GetGoalInputs(Goal g){
            Console.Clear();
            Console.WriteLine("What is the name of your goal?  ");
            g.SetGoal(Console.ReadLine());
            Console.WriteLine("What is a short description of it?  ");
            g.SetDescription(Console.ReadLine());
            Console.WriteLine("What is the amount of points associated with this goal?  ");
            g.SetPoints(int.Parse(Console.ReadLine()));

            if (g.GetType().Name == "ChecklistGoal"){
                Console.WriteLine ("How many times does this goal need to be accomplished for a bonus?  ");
                g.SetNumMax(int.Parse(Console.ReadLine()));
                Console.WriteLine("What is the bonus for accomplishing it that many times?  ");
                g.SetBonusPoints(int.Parse(Console.ReadLine()));
            }
        }
    
    }
}