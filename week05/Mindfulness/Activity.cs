using System.Security.Principal;
using System.Text.RegularExpressions;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void ShowSpinner(int seconds)
    {
        string[] animation = { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animation[i % animation.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    public void StartActivity()
    {
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like for the session?: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready...!!!");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Good Job!");
        ShowSpinner(2);

        Console.WriteLine($"You have completed the {_name} Activity.");
        Console.WriteLine($"You spent {_duration} seconds on this activity");
        ShowSpinner(3);
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected int GetDuration()
    {
        return _duration;
    }
}