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

        while (!isValidInput || _userEntry > _menuList.Count -2 || _userEntry < 1){
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