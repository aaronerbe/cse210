public class Rewards{
    //TODO:  Create lists based on different goals.  Take that input (goal type) to pick which list to build??
    //TODO:  What to do when end of the rewards list!!!
    //TODO:  Animation when achieving a goal

    //keep track of how many rewards given.  So we can increment them each time.  Start w/ -1 so it aligns with the _rewards list (give a reward and this becomes 0, which is the 1st rewards in the list)
    int _rewardsEarned = -1;
    //keep track of how many goals met leading to a reward
    private int _goalsCounter = 0;
    //declare what the trigger is to get a reward
    private int _rewardTrigger = 5;
    //Dictionary to manage key value pair.  INtegers tied to rewards
    Dictionary<int, string> _rewards = new Dictionary<int, string>();

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

    private void BuildRewards(){
        int i = 0;
        _rewards.Add(i++,"Starter");
        _rewards.Add(i++,"Persistence");
        _rewards.Add(i++,"Master");
        _rewards.Add(i++,"Legend");
    }

}