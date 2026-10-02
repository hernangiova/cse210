public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breating", "This Activity will help you relax by walking you through breathing in and out slowly.")
    {

    }
    public void Run()
    {
        StartActivity();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(4);

            if (DateTime.Now >= endTime)
                break;

            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountDown(4);
            Console.WriteLine();
        }

        EndActivity();
    }
}