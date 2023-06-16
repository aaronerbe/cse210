public class ChecklistGoal: Goal{
    
    public ChecklistGoal(bool isNew):base(isNew){
        //use isNew to determine if we need to ask questions (to build a new goal) or if we are reading from a file (existing goal)

        if (isNew){
            Console.WriteLine ("How many times does this goal need to be accomplished for a bonus?  ");
            int userInput =-1;
            //check if it can be parsed to int first, if not, loop till they get it right.  
            while (!int.TryParse(Console.ReadLine(),out userInput)){
                Console.Clear();
                Console.WriteLine("Please enter a valid number.\nHow many times does this goal need to be accomplished for a bonus?  ");
            }
                //send number to the base class
                base.SetNumMax(userInput);
                userInput = -1;  //reset to -1 to use for next input

            Console.WriteLine("What is the bonus for accomplishing it that many times?  ");
            //check if it can be parsed to int first, if not, loop till they get it right.  
            while (!int.TryParse(Console.ReadLine(),out userInput)){
                Console.Clear();
                Console.WriteLine("Please enter a valid number.\nWhat is the bonus for accomplishing it that many times?    ");                
            }
                base.SetBonusPoints(userInput);
        }
    }

    public override void RecordEvent()
    {
        //unique to Checklist. 
        //passing a 1 to tell SetNumDone how many to increment it by.  Did this so (as a future feature), you could have user declare how many times they've compelted the goal. As it is now, it's hard coded to 1 and the function just increments by 1
        base.SetNumDone(1);
        // if number done is >= to number to get bonus, then set goal to complete
        if (base.GetNumDone() >= base.GetNumMax()){
            base.SetComplete(true);
        }
    }
    public override int GetPoints(){
        //checks if they've earned the bonus first.  if so, return the total points earned + the bonus.  Else just return the points earned
        if (base.GetNumDone() >= base.GetNumMax()){
            return base.GetPoints() + base.GetBonus();
        }
        else{
            return base.GetPoints();
        }
    }

    public override string GetXofYSummary(){
        //returns how many they've compelted against the max (criteria to declare if it's done)
        return $" -- Currently completed: {base.GetNumDone()}|{base.GetNumMax()}";
    }

    //!EXTRA:  Add number done in the checkbox for clarity
    public override string GetCheckBox(){
        return base.GetNumDone().ToString();
    }
}