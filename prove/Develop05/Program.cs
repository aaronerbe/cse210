using System;
//!EXTRA REWARDS:
    //Reward badges given for doing x number of achivements for a given goal.  
    //Reward Class + Subclass for each goal type.  Each goal type gets its own list of rewards.
    //The trigger (# of goals in a given goal type needed to trigger a reward) can also be custom within each child reward class
    //The class tracks #of goals completed, then returns back a reward when it hits the trigger.  It then resets the goals counter to track until the next reward.  
        //Note, ANY goal of a type counts towards the Reward of that type.  Meaning, if I have 3 Checklist Goals, completing any of them counts towards earning a Reward for Checklist Goals.  
    //The rewards earned are saved to a file when user saves.
    //Also saves the number of goals earned towards the next reward. This way user doesn't have to start over when reading the file back in.
    //Loading Goals also loads rewards.
    //Option to List the rewards earned.  Organized by Goal Type (since that's how they're earned)
    //Note that even though a Simple goal or Checklist Goal is complete, you can continue to 'complete' the goal again to count towards rewards.
//!EXTRA - User Input Error Handling
    //Handles List Goals, List Rewards, Record and Save when there are no goals yet.  
    //Handles when user selects an invalid goal option to record to
    //Handles when user gives invalid entry in the goals selection menu (not integer or not a valid number from the list)
    //Handles when user doesn't give valid integer for points or bonus
//!EXTRA - Listing Goals Clarity:
    //Checkbox is a little clearer.  Infitinity symbol for eternal goals.  x from X|Y for the checklist goal.  


class Program
{
    static void Main(string[] args)
    {
        //used to create a rewards class for each goal type (simple, eternal, checklist)
        //seting up as a list of them so I can simply loop through it when needed.
        List<Rewards> rewardsList = new List<Rewards>(){
            new SimpleRewards(5),
            new EternalRewards (5),
            new ChecklistRewards(5)
        };
        

        //used to decide if we are creating a new goal or reading it in.
        bool isNew = true;
        //goalsList will keep track of the goals user creates.  Will use this to display them or save them or record them.
        List<Goal> goalsList = new List<Goal>();
        int totalPoints = 0;
        //hard coding the filename for where to save goals and rewards info
        string goalFilename = "goals.txt";
        string rewardsFilename = "rewards.txt";

        //create a menu Instance for Main Menu
        MainMenu MainMenu = new MainMenu();
        Console.Clear();
        //Displays the points before writing the Main Menu to display
        Console.WriteLine($"You have {totalPoints} points.\n");
        //collect the user input from the class method.  Then use it in a while loop, so long as it's not 7 (quit)
        int userMainEntry = MainMenu.DisplayMenu();

        while (userMainEntry != 7){
            switch (userMainEntry){
                case 1:
                    //create a GoalsMenu class to display the sub menu for which goal type.  
                    //Did it this way instead of hard coded so goal menu (types) can be expanded easily later with another child class
                    GoalMenu GoalsMenu = new GoalMenu ();
                    Console.Clear();
                    //same as main menu (since it's the same parent class), collect the entry, then do a switch statement to track how to react.
                    int userSubEntry = GoalsMenu.DisplayMenu();
                    switch (userSubEntry){
                        //for each case, create the Goal child class.  Pass in the isNew boolean.
                        //isNew boolean is to decide if it's the user creating a new goal, or if we are doing this because we read it in from file.  If it's read in from file, we treat it a little differently in the class.  
                        case 1:
                            SimpleGoal s = new SimpleGoal(isNew);
                            //Add the goal class to the goalsList
                            goalsList.Add(s);
                            break;
                        case 2:
                            //Eternal Goal
                            EternalGoal e = new EternalGoal(isNew);
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
                    //check if goalsList is empty meaning they haven't created any goals yet or read any from file.  if it is, skip and give them a message telling them to go back to main menu and create some first.
                    if (goalsList.Count !=0){
                        //calls function to display all the goals and information related to them
                        DisplayFullGoals(goalsList);                        
                    }
                    else{
                        DisplayNoGoalsMsg();
                    }
                    break;
                case 3:
                    //list rewards
                    //Same as list goals, except calls DisplayRewards function to get rewards instead of goals
                    if (goalsList.Count !=0){
                        DisplayRewards(rewardsList);
                    }
                    else{
                        DisplayNoGoalsMsg();
                    }
                    break;
                case 4:
                    //save goals & rewards
                    //Checks if we have goals to save first.  Else warns the user
                    if (goalsList.Count !=0){
                        //I pass a lot into FileHandler because it's handling reading/writing goals and rewards info
                        FileHandler fWrite = new FileHandler(goalFilename, rewardsFilename,rewardsList, goalsList, totalPoints);
                        fWrite.WriteGoals();
                        fWrite.WriteRewards();
                    }
                    else{
                        DisplayNoGoalsMsg();
                    }
                    break;
                case 5:
                    //Load goals
                    //straight forward.  create Filehanlder class and pass all the info to it to let it handle reading in  the files and info.
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
                    //check if list is empty.  proceed if not.  If it is, warn user
                    if (goalsList.Count != 0){
                        DisplayGoals(goalsList);
                        Console.Write("Which goal did you accomplish? ");
                        //capture user input to pass onto RecordGoal function
                        userSubEntry = int.Parse(Console.ReadLine()) -1;
                        //handles within the RecordGoal if user gave an invalid input
                        totalPoints += RecordGoal(userSubEntry, goalsList, totalPoints);
                    }
                    else{
                        DisplayNoGoalsMsg();
                    }
                    break;
            }
            Console.Clear();
            Console.WriteLine($"You have {totalPoints} points.\n");
            userMainEntry = MainMenu.DisplayMenu();
        }

        static void DisplayRewards(List<Rewards> rewardsList){
            //display user rewards earned
            Console.Clear();
            //step through each reward in the rewardsList
            foreach(Rewards r in rewardsList){
                //create a line to start building on to display out.  Starts with the reward type (e.g. Simple)
                string line = ($"{r.GetType().Name}:\n    ");
                //build a list of strings containing all the rewards earned from the reward class (e.g. what was earned in the SimpleRewards class)
                List<string> rewardsString = new List<string>(r.GetRewards());
                //Step through each reward string in the list and append it to the "line" which is then used to display out.
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
            //step through each Goal class in the goalsList
            foreach(Goal g in goalsList){
                //Write out the information for each goal using that goals methods
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
            //same as DsiplayFullGoals but with less info pulled from the class
            foreach(Goal g in goalsList){
                Console.WriteLine($"{i}.  [{g.GetCheckBox()}] {g.GetGoal()}");
                i++;
            }
        }

        int RecordGoal(int entry, List<Goal> goalsList, int totalPoints){
            int pointsEarned = 0;
            //calls the function of the goals class of the goalsList index (selected by user input)
            //recall goalsList is a list of Goals
            //need to check if user selected a valid goal first...
            if (entry >=0 && entry < goalsList.Count){
                goalsList[entry].RecordEvent();
                //get points earned
                pointsEarned = goalsList[entry].GetPoints();
                Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points.");
                Console.WriteLine($"You now have {pointsEarned + totalPoints} points.\n");
                
                //While also recording the goal, trigger the RecordReward function.  Pass the goal type (e.g. Simple) so it knows what reward to track.
                //if a reward is earned with this, the RecordReward will handle displaying that info to the screen.  Else, it proceeds without it.  
                RecordReward(goalsList[entry].GetType().Name);

                Console.WriteLine("Press Enter to return to Main Menu:  ");
                Console.ReadLine();
            }
            else {
                Console.Clear();
                Console.WriteLine("Not a valid entry.");
                Console.ReadLine();
            }
            return pointsEarned;
        }

        void RecordReward(string goal){
            string reward = "";
            //step through each Reward Class in the rewardsList
            foreach(Rewards r in rewardsList){
                //if the reward type (e.g. SimpleReward) contains the name of the the goal types 1st 5 letters (e.g. Simpl from SimpleGoal) then track the reward, else it's the wrong one and move on to the next in the rewards list.
                if (r.GetType().Name.Contains(goal.Substring(0,5))){
                    //Trackreward returns the actual reward earned if they got one.  Else, it remains an empty string.
                    reward = r.TrackReward();
                }
            }
            //check if reward is an empty string.  If it's not that means they earned a reward.  Display it to the screen.  
            if (!string.IsNullOrEmpty(reward)){
                Console.WriteLine($"\n\nCongratulations!  You've earned {goal}: {reward}.  Keep Up the Good work!\n\n");
            }
        }

        static void DisplayNoGoalsMsg(){
            //simple message to handle when user is trying to do something before any goals exist.
            Console.Clear();
            Console.WriteLine("You don't have any recorded goals yet.  \nPress Enter to return to Main Menu, then create a goal first.");
            Console.ReadLine();
        }
    }
}