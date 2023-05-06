public class Menu
{
    //Menu Items
    public string _option1 = "1. Write";
    public string _option2 = "2. Display";
    public string _option3 = "3. Load";
    public string _option4 = "4. Save";
    public string _option5 = "5. Quit";

    //valie input options
    public List<int> _validOptions = new List<int>{1,2,3,4,5};
    
    //User Selection default to 0
    public int _menuOption = 0;

    //save the menu options into a list to be called and displayed
    public List<string> menu = new List<string>();

    public Menu()
    {
        menu.Add(_option1);
        menu.Add(_option2);
        menu.Add(_option3);
        menu.Add(_option4);
        menu.Add(_option5);
    }   
}