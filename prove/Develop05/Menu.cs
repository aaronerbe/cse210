public abstract class Menu{
    private List<string> _menuList = new List<string>();
    private int _userEntry = 0;

    public Menu(){
        //build menu list
        //BuildMenuList();
    }

    public int DisplayMenu(){
        WriteMenuItems();
        //check for valid input, if not rewrite menu with modified msg
        bool isValidInput = CheckIfValid();
        
        //isValidInput is a bool based on trying to parse to int.  So if it's not an integer or if they give an integer out of the range of the menu, it'll keep rewriting
        while (!isValidInput || _userEntry > _menuList.Count -2 || _userEntry < 1){
            Console.Clear();
            Console.WriteLine("Invalid Entry.  Please choose a valid Menu Item.");
            WriteMenuItems();
            isValidInput = CheckIfValid();
        }
        return _userEntry;
    }
    private void WriteMenuItems(){
        //Console.Clear();
        foreach (string i in _menuList){
            Console.Write(i);
        }
    }
    private bool CheckIfValid(){
        return int.TryParse(Console.ReadLine(),out _userEntry);
    }
    //public int GetMenuCount(){
    //    return _menuList.Count;
    //}
    public void AddMenuItem(string menuItem){
        _menuList.Add(menuItem);
    }
    public abstract void BuildMenu();
}