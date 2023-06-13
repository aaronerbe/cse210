class SimpleRewards:Rewards{

    public SimpleRewards(int trigger): base(trigger){

    }

    public override void BuildRewards(){
        int i = 0;
        AddRewardItem(i++,"One At A Time");
        AddRewardItem(i++,"Keeping it Simple");
        AddRewardItem(i++,"Rack 'em Up");
        AddRewardItem(i++,"Climbing the Mountain");
    }

}