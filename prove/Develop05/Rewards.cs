public abstract class Rewards{
    //TODO:  What to do when end of the rewards list!!!
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
        _goalsCounter++;

        if (_goalsCounter == _rewardTrigger){
            _goalsCounter = 0;
            //_rewardsEarned.Add(_rewardsEarned.Count()+1);
            _rewardsEarned++;
            return _rewards[_rewardsEarned];
        }
        else{
            return "";
        }
    }

    public abstract void BuildRewards();
    
    //used so child class can add custom rewards based on it's type (eternal, simple, etc)
    public void AddRewardItem(int i, string rewardItem){
        _rewards.Add(i,rewardItem);
    }

    public List<string> GetRewards(){
        List<string> rewardsEarnedList = new List<string>(){""};
        
        if (_rewardsEarned!=-1){
            for (int i = 0; i<_rewardsEarned; i++){
                rewardsEarnedList.Add(_rewards[i]);        
            }
        }
        return rewardsEarnedList;
    }
    public int GetGoalsCounter(){
        return _goalsCounter;
    }

    public void SetRewardsEarned(int rewardsEarned){
        _rewardsEarned = rewardsEarned;
    }
    public void SetGoalsCounter(int goalsCounter){
        _goalsCounter = goalsCounter;
    }

}