class EternalRewards:Rewards{

    public EternalRewards(int trigger): base(trigger){

    }

    public override void BuildRewards(){
        int i = 0;
        AddRewardItem(i++,"Starter");
        AddRewardItem(i++,"Persistence");
        AddRewardItem(i++,"Master");
        AddRewardItem(i++,"Legend");
    }

}