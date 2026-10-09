public class EternalGoal : Goal
{
    private int _times;

    public EternalGoal(string name, string description, int points, int times = 0) : base(name, description, points)
    {
        _times = times;
    }

    public override int RecordEvent()
    {
        _times++;

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetName()} - Recorded {_times} times";
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal|{GetName()}|{GetDescription()}|{GetPoints()}|{_times}";
    }
}