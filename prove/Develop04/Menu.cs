class Menu{
    List<string> _menuList = new List<string>();
    int _userEntry = 0;

    public Menu(){
        BuildMenuList();
    }

    public int DisplayMenu(){
        foreach (string i in _menuList){
            Console.WriteLine(i);
        }
        _userEntry = int.Parse(Console.ReadLine());
        return _userEntry;
    }

    private void BuildMenuList(){
        _menuList.Add("1.  Breathing Activity");
        _menuList.Add("2.  Reflection Activity");
        _menuList.Add("3.  Listing Activity");
        _menuList.Add("4.  Quit");
    }
}
