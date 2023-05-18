//Exceeding CORE Requirements:
    //Program verifies filename is valid before loading.  Warns user it's an invalid filename if not.
    //As the program randomly selects from the prompts list, it removes that prompt so it doesn't come back up.  
    //If the user exhuasts all prompts, it informs them there are not more prompt questions. 
    //Program verifies that the menu entry from the user is valid.  If not, it continues looping Warning the entry is invlid and displaying the menu options.  
    //Pulled Menu into its own class to simplify code.  

class Program
{
    static void Main(string[] args)
    {
        Prompts p = new Prompts();
        Menu m = new Menu();
        Entry e = new Entry();
        Journal j = new Journal();

        //Call DisplayMenu & return/save the menuOption user has selected inside of the DisplayMenu function
        m.DisplayMenu();

        //While Loop to run until user selects 5
        while (m._menuOption != 5)   
        {
            switch(m._menuOption)
            {
                case 1:
                    //Create New Entry & Display Menu
                    e.BuildEntry(p, e);
                    m.DisplayMenu();
                    break;
                case 2:
                    //Call DisplayMenu & Display Menu
                    e.DisplayEntry(e);
                    m.DisplayMenu();
                    break;
                case 3:
                    //Load File & Display Menu
                    j.LoadFromFile(e);
                    m.DisplayMenu();
                    break;
                case 4:
                    //Save File & Display Menu
                    j.SaveToFile(e);
                    m.DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Bad Menu Entry");
                    m.DisplayMenu();
                    break;
            }
        }
        Console.WriteLine("\nExiting\n");
    }
}