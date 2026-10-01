using System;
class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Heissel Cruz", "Divisiones");

        Console.WriteLine();
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine();

        MathAssignment math = new MathAssignment("Roberto Merida", "Fractions", "6.3", "9-22");

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment writing = new WritingAssignment("Maribelita Cruz", "European History", "The World War II");

        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
        Console.WriteLine();
    }
}