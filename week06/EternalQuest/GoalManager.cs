public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    public string GetLevel()
    {
        if (_score >= 3000)
            return "Legend";

        if (_score >= 1500)
            return "Hero";

        if (_score >= 500)
            return "Adventurer";

        return "Beginner";
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent(int number)
    {
        if(number < 1 || number > _goals.Count)
    {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[number - 1];

        if (goal.IsComplete())
        {
            Console.WriteLine("This goal is already complete.");
            return;
        }

        int points = goal.RecordEvent();
        _score += points;

        Console.WriteLine($"You earned {points} points!");
        Console.WriteLine($"Total score: {_score}");
    }

    public void Save(string filename)
    {
        using (StreamWriter write = new StreamWriter(filename))
        {
            write.WriteLine($"Score|{_score}");

            foreach (Goal goal in _goals)
            {
                write.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("File saved");
    }

    public void Load(string filename)
    {

        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();
        string[] lines = File.ReadAllLines(filename);
        int loadedScore = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts[0].Trim() == "Score")
            {
                int.TryParse(parts[1], out loadedScore);
            }
            else if (parts[0] == "Simple" && parts.Length == 5)
            {
                loadedGoals.Add(new SimpleGoal(
                parts[1],
                parts[2],
                int.Parse(parts[3]),
                bool.Parse(parts[4])));
            }
            else if (parts[0] == "Eternal" && parts.Length == 5)
            {
                loadedGoals.Add(new EternalGoal(
                parts[1],
                parts[2],
                int.Parse(parts[3]),
                int.Parse(parts[4])));
            }
            else if (parts[0] == "Checklist" && parts.Length == 7)
            {
                loadedGoals.Add(new ChecklistGoal(
                parts[1],
                parts[2],
                int.Parse(parts[3]),
                int.Parse(parts[4]),
                int.Parse(parts[5]),
                int.Parse(parts[6])));
            }
        }

        _goals = loadedGoals;
        _score = loadedScore;
        Console.WriteLine("File loaded");
    }
}