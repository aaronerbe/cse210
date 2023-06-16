class ChecklistRewards:Rewards{

    public ChecklistRewards(int trigger): base(trigger){
        //gets the trigger (how many goals needed to trigger a reward) and passes on to the base class
    }

    public override void BuildRewards(){
        //builds it's own list of rewards unique to this type of class
        int i = 0;
        AddRewardItem(i++,"Get 'er Done");
        AddRewardItem(i++,"Task Master");
        AddRewardItem(i++,"Checkered Flag");
        AddRewardItem(i++,"Check Mate");
    }

}