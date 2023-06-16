class EternalRewards:Rewards{

    public EternalRewards(int trigger): base(trigger){
        //gets the trigger (how many goals needed to trigger a reward) and passes on to the base class
    }

    public override void BuildRewards(){
        int i = 0;
        //builds it's own list of rewards unique to this type of class
        AddRewardItem(i++,"Starter");
        AddRewardItem(i++,"Persistence");
        AddRewardItem(i++,"Master");
        AddRewardItem(i++,"Legend");
    }

}