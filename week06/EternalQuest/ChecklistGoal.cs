public class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _completed;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed = 0) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (_completed >= _target)
        {
            return 0;
        }

        _completed++;

        if (_completed == _target)
        {
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _completed >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";

        return $"{status} {GetName()} - Completed {_completed}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist|{GetName()}|{GetDescription()}|{GetPoints()}|{_target}|{_bonus}|{_completed}";
    }
}