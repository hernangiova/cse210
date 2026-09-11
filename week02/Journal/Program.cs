using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();


        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = prompts[random.Next(prompts.Count)];

                Console.WriteLine(prompt);
                Console.WriteLine("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry(date, prompt, response);

                journal.AddEntry(newEntry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.WriteLine("What is the filename? ");
                string filename = Console.ReadLine();

                Console.WriteLine("Journal saved successfully.");
            }
            else if (choice == 4)
            {
                Console.WriteLine("What is the filename? ");
                string filename = Console.ReadLine();

                Console.WriteLine("Journal loaded successfully.");
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }

        }
    }
}