class ChecklistRewards:Rewards{

    public ChecklistRewards(int trigger): base(trigger){

    }

    public override void BuildRewards(){
        int i = 0;
        AddRewardItem(i++,"Get 'er Done");
        AddRewardItem(i++,"Task Master");
        AddRewardItem(i++,"Checkered Flag");
        AddRewardItem(i++,"Check Mate");
    }

}