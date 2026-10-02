public class ReflectionActivity : Activity
{
    private string[] _prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] _questions =
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectionActivity() : base("Reflection", "This Activity will help you to reflect on time in your life when you have shown strength and resilience.")
    {

    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine();

        int promptIndex = _random.Next(_prompts.Length);
        Console.WriteLine($"-- {_prompts[promptIndex]} --");
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press ENTER to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            int questionIndex = _random.Next(_questions.Length);

            Console.WriteLine();
            Console.WriteLine(_questions[questionIndex]);
            ShowSpinner(5);
        }
        EndActivity();
    }
}