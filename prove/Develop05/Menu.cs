public abstract class Menu{
    private List<string> _menuList = new List<string>();
    private int _userEntry = 0;

    public Menu(){
        //Not building the list cause this is an abstract class.  the child classes will build the menu list they need.  This class will handle the behaviors
    }

    public int DisplayMenu(){
        //writes the menuList to display
        WriteMenuItems();
        //check that user entered an integer
        bool isValidInput = CheckIfValid();
        //isValidInput is a bool based on trying to parse to int.  So if it's not an integer or if they give an integer out of the range of the menu, it'll keep rewriting
        while (!isValidInput || _userEntry > _menuList.Count -2 || _userEntry < 1){
            Console.Clear();
            Console.WriteLine("Invalid Entry.  Please choose a valid Menu Item.");
            WriteMenuItems();
            //check again if input is valid.
            isValidInput = CheckIfValid();
        }
        return _userEntry;
    }
    private void WriteMenuItems(){
        //step through each item in the menulist (created by child class)
        foreach (string i in _menuList){
            Console.Write(i);
        }
    }
    private bool CheckIfValid(){
    //simply checking if the input from user is an integer
        return int.TryParse(Console.ReadLine(),out _userEntry);
    }

    public void AddMenuItem(string menuItem){
        //behavior for building the menuLIst.  Called by child classes to create unique menus.  
        _menuList.Add(menuItem);
    }
    public abstract void BuildMenu();
    //override from child class.  The child class will have unique build behaviors (unique lists)
}