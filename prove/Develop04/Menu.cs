//EXTRA, error handling for menu options if somoene enters invalid option (string or invalid menu number)
class Menu{
    private List<string> _menuList = new List<string>();
    private int _userEntry = 0;

    public Menu(){
        //once initiated, it'll build the _menuList
        BuildMenuList();
    }

    public int DisplayMenu(){
        //write out each line of the _menuList
        foreach (string i in _menuList){
            Console.WriteLine(i);
        }
        //This line isn't part of the menu so we can easily change it to warn the user if they are entering the wrong input.
        Console.Write("Select a choice from the menu:  ");
        //test if it is an integer, if so, grab it
        bool isValidInput = int.TryParse(Console.ReadLine(),out _userEntry);
        //while it's not an integer Or not a valid number in the list, rewrite the menu with a message.  Written such that the menu can be expanded without needing to update this piece of code.  
        while (!isValidInput || _userEntry > _menuList.Count-1 || _userEntry < 1){
            Console.Clear();
            //re-write the menu list
            foreach (string i in _menuList){
                Console.WriteLine(i);
            }
            //modified message to warn them they put in the wrong entry
            Console.Write("Invalid Selection.  Please select a choice from the menu:  ");
            isValidInput = int.TryParse(Console.ReadLine(),out _userEntry);
        }
        //return the entry
        return _userEntry;
    }

    //Used to make the menu on the main program independent.  Meaning, I can update the menu class without having to change code in main program.  Like I did when creating the Prayer class
    public int GetMenuCount(){
        return _menuList.Count;
    }

    private void BuildMenuList(){
        _menuList.Add("Menu Options:");
        _menuList.Add("1.  Breathing Activity");
        _menuList.Add("2.  Reflection Activity");
        _menuList.Add("3.  Listing Activity");
        _menuList.Add("4.  Prayer Activity");
        _menuList.Add("5.  Quit");
    }
}
