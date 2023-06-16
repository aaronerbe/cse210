class SimpleRewards:Rewards{

    public SimpleRewards(int trigger): base(trigger){
        //gets the trigger (how many goals needed to trigger a reward) and passes on to the base class
    }

    public override void BuildRewards(){
        int i = 0;
        //builds it's own list of rewards unique to this type of class
        AddRewardItem(i++,"One At A Time");
        AddRewardItem(i++,"Keeping it Simple");
        AddRewardItem(i++,"Rack 'em Up");
        AddRewardItem(i++,"Climbing the Mountain");
    }

}