using System;

class Program
{
    static void Main(string[] args)
    {
        //filename of csv with video info
        string filename = "VideoCSV.txt";
        //list of video classes
        List<Video> v = new List<Video>();
        //filehandler class to open csv
        FileHandler f =  new FileHandler(filename);
        //read the file and return back the list of videos
        v = f.ReadFile();
        //display to console all the video info
        DisplayInfo(v);
    }

    //Moved display work into the Video Class to display itsown info instead of passing it all back to program.  Much cleaner.  
    static void DisplayInfo(List<Video> videos){
        foreach (Video v in videos){
            v.DisplayVideoInfo();
        }
    }
}