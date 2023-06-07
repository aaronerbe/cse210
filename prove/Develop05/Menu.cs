public class Menu{
    private List<string> _menuList = new List<string>();
    private int _userEntry = 0;

    public Menu(){
        //build menu list
        BuildMenuList();
    }

    public int DisplayMenu(){
        foreach (string i in _menuList){
            Console.WriteLine(i);
        }
        Console.Write("Select a choice from the menu:  ");

        //check for valid input, if not rewrite menu with modified msg
        bool isValidInput = int.TryParse(Console.ReadLine(), out _userEntry);
        while (!isValidInput || _userEntry > _menuList.Count || _userEntry < 1){
            Console.Clear();
            foreach(string i in _menuList){
                Console.WriteLine(i);
            }
            Console.Write("Invalid Selection.  Please select a choice from the menu:  ");
        }

        return _userEntry;
    }

    public int GetMenuCount(){
        return _menuList.Count;
    }

    //TODO:  Pass the list of menu options to the class instead.  This way it can handle submenu (e.g. now pick 1-3 for which goal you want to do)
    private void BuildMenuList(){
        _menuList.Add("Menu Options");
        _menuList.Add("1. Create Goal");
        _menuList.Add("2. Record Goal");
        _menuList.Add("3. Load File");
        _menuList.Add("4. Save to File");
        _menuList.Add("5. Quit");
    }
}