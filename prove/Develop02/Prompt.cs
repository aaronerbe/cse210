public class Prompts
{ 
    string _prompt1 = "Who was the most interesting person I interacted with today?";
    string _prompt2 = "What was the best part of my day?";
    string _prompt3 = "How did I see the hand of the Lord in my life today?";
    string _prompt4 = "What was the strongest emotion I felt today?";
    string _prompt5 = "If I had one thing I could do over today, what would it be?";
    string _prompt6 = "What challenges did I overcome today?";
    string _prompt7 = "What did I do to achieve my goals today?";
    string _prompt8 = "What inspiration did I recieve today?";

    public List<string> _prompt = new List<string>();
    public int _randomIndex;

    public Prompts()
    {
        _prompt.Add(_prompt1);
        _prompt.Add(_prompt2);
        _prompt.Add(_prompt3);
        _prompt.Add(_prompt4);
        _prompt.Add(_prompt5);
        _prompt.Add(_prompt6);
        _prompt.Add(_prompt7);
        _prompt.Add(_prompt8);
    }   
}