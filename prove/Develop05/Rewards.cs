public abstract class Rewards{
    //TODO:  Animation when achieving a goal

    //keep track of how many rewards given.  So we can increment them each time.  Start w/ -1 so it aligns with the _rewards list (give a reward and this becomes 0, which is the 1st rewards in the list)
    private  int _rewardsEarned = -1;
    //keep track of how many goals met leading to a reward
    private int _goalsCounter = 0;
    //declare what the trigger is to get a reward
    private int _rewardTrigger = 5;
    //Dictionary to manage key value pair.  INtegers tied to rewards
    private Dictionary<int, string> _rewards = new Dictionary<int, string>();

    //when Goal creates Rewards class, it sets the rewardTrigger (how many goals complete until recieving a reward)
    public Rewards(int rewardTrigger){
        BuildRewards();
        _rewardTrigger = rewardTrigger;
    }

    //called by the goals when user is recording an event.  meant to send a trigger to Rewards class to increment and see if they've earned a reward.  return the reward string if so.  
    public string TrackReward(){
        //increment right away cause user completed another goal (this is called from Record Goal option)
        _goalsCounter++;
        //if rewardsEarned = count of _rewards list, it means we've exhuasted all the rewards to be earned.  So return nothing going fowards.  Needed so we don't overrun the list (try to return an index that doesn't exist)
        //have to do _rewardsEarned + 1 to align with the count format
        if (_rewardsEarned + 1 == _rewards.Count()){
            return "";
        }
        //if we've completed enough goals to match the trigger number, then they earn another reward
        else if (_goalsCounter == _rewardTrigger){
            //reset goal counter to 0 to start counting towards next reward
            _goalsCounter = 0;
            //increment _rewardsEarned which keeps track of how many rewards they've gotten.  This is used to read out from the Rewards list what they've earned (e.g. if _rewardsEarned = 2, youd return back the 1st 2 items from the list to display them or save to a file)
            _rewardsEarned++;
            //Returns that reward directly 
            return _rewards[_rewardsEarned];
        }
        else{
            //if they don't earn a reward, return empty string (nothing earned)
            return "";
        }
    }

    //Overridden by child class to pass a custom list of rewards into the _rewards list.  
    public abstract void BuildRewards();
    
    public void AddRewardItem(int i, string rewardItem){
    //used by child class "BuildRewards" which builds the list of rewards.  Child class uses an override of BuildRewards, then calls this to add the specific list.
        _rewards.Add(i,rewardItem);
    }

    public List<string> GetRewards(){
        //Used to display or save what rewards have been earned.  I keep track of what has been earned with the _rewardsEarned attribute which is just a count.
        //create an empty list
        List<string> rewardsEarnedList = new List<string>(){""};
        //if _rewardsEarned = -1, it means we haven't earned any yet
        if (_rewardsEarned!=-1){
            //increment through the _rewards list up to the _rewardsEarned and put it in our temporary list.
            for (int i = 0; i<=_rewardsEarned; i++){
                rewardsEarnedList.Add(_rewards[i]);        
            }
        }
        //return the temporary list to display or save
        return rewardsEarnedList;
    }
    public int GetGoalsCounter(){
        //used for saving to file.  I keep track ofhow many goals they've completed towards the next reward.  Save this so they don't have to start over.
        return _goalsCounter;
    }
    public void SetRewardsEarned(int rewardsEarned){
        //Used when reading from file to setup the class with the info it needs.  _rewardsEarned keeps track of how many they've earned from the list
        _rewardsEarned = rewardsEarned;
    }
    public void SetGoalsCounter(int goalsCounter){
        //Also used when reading from file to setup the class with the info it needs.  If file tracked user had 3 goals completed, we setup the new class with that here.  
        _goalsCounter = goalsCounter;
    }

}