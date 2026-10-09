using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== ETERNAL QUEST ===");
            Console.WriteLine($"Score: {manager.GetScore()}");
            Console.WriteLine($"Level: {manager.GetLevel()}");

            Console.WriteLine("\n1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                CreateGoal(manager);
            }
            else if (choice == "2")
            {
                manager.DisplayGoals();
            }
            else if (choice == "3")
            {
                manager.DisplayGoals();

                if (manager.GetGoals().Count > 0)
                {
                    Console.Write("Goal number: ");

                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        manager.RecordEvent(number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.");
                    }
                }
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(filename))
                {
                    manager.Save(filename);
                }
            }
            else if (choice == "5")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(filename))
                {
                    manager.Load(filename);
                }
            }
            else if (choice == "6")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nGoal type:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        Console.Write("Choose: ");

        string type = Console.ReadLine() ?? "";

        if (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine("Invalid type.");
            return;
        }

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(description) ||
            name.Contains("|") || description.Contains("|"))
        {
            Console.WriteLine("Enter a valid name and description.");
            return;
        }

        Console.Write("Points: ");

        if (!int.TryParse(Console.ReadLine(), out int points) ||
            points < 0)
        {
            Console.WriteLine("Invalid points.");
            return;
        }

        Goal goal;

        if (type == "1")
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == "2")
        {
            goal = new EternalGoal(name, description, points);
        }
        else
        {
            Console.Write("Target: ");

            if (!int.TryParse(Console.ReadLine(), out int target) ||
                target < 1)
            {
                Console.WriteLine("Invalid target.");
                return;
            }

            Console.Write("Bonus points: ");

            if (!int.TryParse(Console.ReadLine(), out int bonus) ||
                bonus < 0)
            {
                Console.WriteLine("Invalid bonus.");
                return;
            }

            goal = new ChecklistGoal(
                name, description, points, target, bonus);
        }

        manager.AddGoal(goal);
        Console.WriteLine("Goal created!");
    }
}