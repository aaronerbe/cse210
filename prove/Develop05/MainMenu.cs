public class MainMenu : Menu{    
    public MainMenu(){
        BuildMenu();
    }
    public override void BuildMenu(){
        base.AddMenuItem("Menu Options\n");
        base.AddMenuItem("1. Create New Goal\n");
        base.AddMenuItem("2. List Goals\n");
        base.AddMenuItem("3. List Rewards\n");
        base.AddMenuItem("4. Save Goals & Rewards\n");
        base.AddMenuItem("5. Load Goals & Rewards\n");
        base.AddMenuItem("6. Record Event\n");
        base.AddMenuItem("7. Quit\n");
        base.AddMenuItem("Select a choice from the menu:  ");
    }
}