//Available Animations:  Spin, PingPong, Ring, Grow, Countdown
class Animation{
    int _duration; 

    public Animation(){
        _duration = 0;
    }
    
    public void RunAnimation(int duration, string type){
        _duration = duration;
        switch (type.ToLower()){
            case "spin":
                Spinner(_duration);
                break;
            case "pingpong":
                PingPong(_duration);
                break;
            case "ring":
                Ring(_duration);
                break;
            case "grow":
                Grow(_duration);
                break;
            case "countdown":
                Countdown(_duration);
                break;
        }
    }
    private void Spinner(int duration){
        List<string> animationList = new List<string>();
        animationList.Add("|");
        animationList.Add("/");
        animationList.Add("-");
        animationList.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        int i = 0;
        //Console.Clear();
        while (DateTime.Now < endTime){
            Console.Write(animationList[i]);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i = (i + 1) % animationList.Count;
        }        
    }
    private void PingPong(int duration){

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        //Console.Clear();
        while (DateTime.Now < endTime){
            Console.CursorVisible = false;
            for (int i = 0; i<5; i++ ){
                Console.Write(".");
                Thread.Sleep(1000);
            }
            for (int i = 0; i<5; i++){
                Console.Write("\b \b");
                Thread.Sleep(1000);                
            }
        }
        Console.CursorVisible = true;
    }
    private void Ring(int duration){

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        List<string> RingList = new List<string>();
        RingList.Add("    --  ");
        RingList.Add("        \\");
        RingList.Add("         |");
        RingList.Add("        /");
        RingList.Add("    --");
        RingList.Add(" \\      /");
        RingList.Add("|        |");
        RingList.Add(" /      \\");
        //trigger looks for this exactly to flip boolean
        RingList.Add("        ");
        RingList.Add(" /       ");
        RingList.Add("|         ");
        RingList.Add(" \\       ");
        //trigger looks for this exactly to flip boolean
        RingList.Add("        ");
        //extra space to not trigger the midpoint
        RingList.Add("         ");
        RingList.Add("         ");
        RingList.Add("         ");

        int i = 0;
        //Console.Clear();
        bool down = false;
        //Make room for the animation:
        Console.WriteLine("\n\n\n\n\n");
        Console.SetCursorPosition(0,Console.CursorTop - 5);
        //Hide the cursor
        Console.CursorVisible = false;
        while (DateTime.Now < endTime){
            //if Ringlist = exactly this # of spaces or "-" to trigger the mid points
            if (RingList[i] == "        " || RingList[i].Contains("-")){
                //Flip the boolean to go up or down
                if (down == true){
                    down = false;
                }
                else{
                    down = true;
                }
            }
            //if down = true, write the line then move down
            if (down == true){
                Console.Write(RingList[i]);
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, Console.CursorTop + 1);
            }
            //if down = false, write the line then move up
            if (down == false){
                Console.Write(RingList[i]);
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, Console.CursorTop - 1); 
            }
        //increment i up until count, then wraps around again to 0
        i = (i + 1) % RingList.Count;
        }

        //Console.Clear();
        Console.CursorVisible = true;
    }
    private void Grow(int duration){

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        List<string> RingList = new List<string>();
        //RingList.Add("\n\n\n\n\n\n\n ");
        //RingList.Add("      ");
        RingList.Add("     -");
        RingList.Add("    ---");
        RingList.Add("   -----");
        RingList.Add("  -------");
        RingList.Add(" ---------");

        int i = 0;
        bool grow = true;

        //hide the cursor, clear the console and move down a few spaces to make room for the growing animation
        Console.CursorVisible = false;
        //Console.Clear();
        Console.WriteLine("\n\n\n\n");

        //while we're within the duration
        while (DateTime.Now < endTime){
            //hide the cursor for the animation
            Console.CursorVisible = false;
            //if we're starting out, grow up
            if (i == 0){
                grow = true;
            }
            //if we hit the max in the list, go back down
            if (i == RingList.Count){
                grow = false;
            }
            if (grow == true){
                //grow = true means write the next line and then move up in the console
                Console.Write(RingList[i]);
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                i++;
            }
            else{
                //grow = false means decrease and erase the line (replace with spaces)
                Console.Write("                                        ");
                Thread.Sleep(1000);
                //move down to the next line
                Console.SetCursorPosition(0, Console.CursorTop + 1);
                i--;
            }
            //make the cursor visibile again
            Console.CursorVisible = true;
        } 
        //Console.Clear();
    }
    private void Countdown(int duration){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        //Console.Clear();
        int i = duration;
        Console.Write("You may begin in: ");
        while (DateTime.Now < endTime){
            Console.Write(i);
            Thread.Sleep(1000);
            //Console.Write("\b\b\b   \b\b\b");
            Console.SetCursorPosition(0, Console.CursorTop + 0);
            Console.Write("You may begin in: ");
            i--;
        }
        Console.SetCursorPosition(0, Console.CursorTop + 0);
        Console.Write("Begin:                 ");
        Console.WriteLine("\n");
    }


}