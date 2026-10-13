using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running activity1 = new Running("12 Oct 2026", 30, 3.0);
        Cycling activity2 = new Cycling("11 Oct 2026", 45, 12.0);
        Swimming activity3 = new Swimming("19 April 2026", 40, 40);

        activities.Add(activity1);
        activities.Add(activity2);
        activities.Add(activity3);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}