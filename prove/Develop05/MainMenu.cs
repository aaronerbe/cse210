public class MainMenu : Menu{    
    public MainMenu(){
        BuildMenu();
    }
    public override void BuildMenu(){
        base.AddMenuItem("Menu Options\n");
        base.AddMenuItem("1. Create New Goal\n");
        base.AddMenuItem("2. List Goals\n");
        base.AddMenuItem("3. Save Goals\n");
        base.AddMenuItem("4. Load Goals\n");
        base.AddMenuItem("5. Record Event\n");
        base.AddMenuItem("6. Quit\n");
        base.AddMenuItem("Select a choice from the menu:  ");
    }
}