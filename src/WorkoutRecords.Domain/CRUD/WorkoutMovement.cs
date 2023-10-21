namespace WorkoutRecords.Domain.CRUD;

public class WorkoutMovement
{
    public Movement Movement { get; set; } = new();

    public int RepsCount { get; set; }

    public int Weight { get; set; }

    public int Distance { get; set; }
}
