public class GoalMenu : Menu{

    public GoalMenu(){
        BuildMenu();
    }
    public override void BuildMenu(){
        base.AddMenuItem("The types of Goals are:\n");
        base.AddMenuItem("1. Simple Goal\n");
        base.AddMenuItem("2. Eternal Goal\n");
        base.AddMenuItem("3. Checklist Goal\n");
        base.AddMenuItem("Which type of goal would you like to create?  ");
    }
}