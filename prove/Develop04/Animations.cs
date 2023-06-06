//Available Animations:  Spin, PingPong, Ring, Grow, Countdown
class Animation{
    int _duration; 

    public Animation(){
        _duration = 0;
    }
    
    //Is used to call whichever animation is needed.  Controlled by a switch case and keywords.  Also passes on a message that can be used in some animations.
    public void RunAnimation(int duration, string type, string msg){
        _duration = duration;
        switch (type.ToLower()){
            case "spin":
                //doing /2 cause the normal pause seems long for the 'get ready' pauses.  
                Spinner(_duration/2, msg);
                break;
            case "pingpong":
                PingPong(_duration);
                break;
            case "ring":
                Ring(_duration);
                break;
            case "breathe":
                Breathe(_duration);
                break;
            case "countdown":
                Countdown(_duration, msg);
                break;
        }
    }

    //basic spinner animation.  Used with a message.  Usually "Get ready..."
    private void Spinner(int duration, string msg){
        List<string> animationList = new List<string>();
        animationList.Add("|");
        animationList.Add("/");
        animationList.Add("-");
        animationList.Add("\\");

        //uses datetime to only run the animation for the length based on duration set.  
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        //hide cursor to make it prettier
        Console.CursorVisible = false;
        Console.WriteLine(msg);
        int i = 0;
        //run until duration is met
        while (DateTime.Now < endTime){
            //step through the list of animations to create the spinning effect
            Console.Write(animationList[i]);
            //short pause in between
            Thread.Sleep(100);
            //backs up writes a space then backs up again to prep writing the next animation step
            Console.Write("\b \b");
            //this will increment i until we hit the end of the list, then sets back to zero
            i = (i + 1) % animationList.Count;
        }    
        //turn the cursor back on    
        Console.CursorVisible = true;
    }
    private void PingPong(int duration){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        while (DateTime.Now < endTime){
            Console.CursorVisible = false;
            //increments up writing a . each time until it hits 5 dots
            for (int i = 0; i<5; i++ ){
                Console.Write(".");
                Thread.Sleep(200);
            }
            //then increments up removing a dot each time
            for (int i = 0; i<5; i++){
                Console.Write("\b \b");
                Thread.Sleep(200);                
            }
        }
        Console.CursorVisible = true;
    }
    private void Ring(int duration){
        //not used but was fun to make
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        //each step needed to create an incrementally growing ring, then incrementally degrading ring.  
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
        Console.CursorVisible = true;
    }
    private void Breathe(int duration){

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        //the simple growing animation
        List<string> RingList = new List<string>();
        RingList.Add("     -");
        RingList.Add("    ---");
        RingList.Add("   -----");
        RingList.Add("  -------");
        RingList.Add(" ---------");

        int i = 0;
        //use a boolean to determine if it should be growing or shrinking
        bool grow = true;

        //hide the cursor, clear the console and move down a few spaces to make room for the growing animation
        Console.CursorVisible = false;
        //Console.Clear();
        Console.WriteLine("\n\n\n\n");
        string msg = "Breathe in...";
        //while we're within the duration
        while (DateTime.Now < endTime){
            //hide the cursor for the animation
            Console.CursorVisible = false;
            //if we're starting out, grow up by setting grow to true and resetting msg to breathe in
            if (i == 0){
                grow = true;
                msg = "Breathe in...";
                //Quickly jump to top and reset the lineo of text to Breathe In, then jump back for the animation
                Console.SetCursorPosition(0,Console.CursorTop -6);
                Console.Write(msg);
                Console.SetCursorPosition(0,Console.CursorTop + 6);
            }
            //if we hit the max in the animation list, go back down by setting grow to false and resetting msg to breathe out
            if (i == RingList.Count){
                grow = false;
                msg = "Breathe out...";
                //Quickly jump to top and reset the lineo of text to Breathe In, then jump back for the animation
                Console.SetCursorPosition(0,Console.CursorTop -1);
                Console.Write(msg);
                Console.SetCursorPosition(0,Console.CursorTop + 1);
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
    }

    private void Countdown(int duration, string msg){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        //Console.Clear();
        int i = duration;
        //write the message passed on.
        Console.Write(msg);
        while (DateTime.Now < endTime){
            Console.Write(i);
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, Console.CursorTop + 0);
            Console.Write(msg);
            i--;
        }
        Console.SetCursorPosition(0, Console.CursorTop + 0);
        //clears out the left over '1' after the countdown
        Console.Write(msg+ "      ");
        Console.WriteLine("\n");
    }
}