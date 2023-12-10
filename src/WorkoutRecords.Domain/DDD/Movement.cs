using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Movement : Enumeration
{
    public static readonly Movement Rest = new(0, nameof(Rest));
    public static readonly Movement PullUp = new(1, "Pull-Up");
    public static readonly Movement PushUp = new(2, "Push-Up");
    public static readonly Movement SitUp = new(3, "Sit-Up");
    public static readonly Movement Squat = new(4, nameof(Squat));
    public static readonly Movement Burpee = new(5, nameof(Burpee));
    public static readonly Movement Run = new(6, nameof(Run));
    public static readonly Movement Row = new(7, nameof(Row));
    public static readonly Movement Bike = new(8, nameof(Bike));
    public static readonly Movement SingleUnder = new(9, "Single Under");
    public static readonly Movement DoubleUnder = new(10, "Double Under");
    public static readonly Movement Thruster = new(11, nameof(Thruster));
    public static readonly Movement WallBall = new(12, "Wall Ball");
    public static readonly Movement BoxJump = new(13, "Box Jump");
    public static readonly Movement BoxStepUp = new(14, "Box Step-Up");
    public static readonly Movement BoxJumpOver = new(15, "Box Jump Over");
    public static readonly Movement Deadlift = new(16, nameof(Deadlift));
    public static readonly Movement Clean = new(17, nameof(Clean));
    public static readonly Movement Snatch = new(18, nameof(Snatch));
    public static readonly Movement Jerk = new(19, nameof(Jerk));
    public static readonly Movement Press = new(20, nameof(Press));
    public static readonly Movement BenchPress = new(21, nameof(BenchPress));
    public static readonly Movement OverheadSquat = new(22, nameof(OverheadSquat));
    public static readonly Movement FrontSquat = new(23, nameof(FrontSquat));
    public static readonly Movement BackSquat = new(24, nameof(BackSquat));
    public static readonly Movement ShoulderToOverhead = new(25, nameof(ShoulderToOverhead));
    public static readonly Movement PowerClean = new(26, nameof(PowerClean));
    public static readonly Movement PowerSnatch = new(27, nameof(PowerSnatch));
    public static readonly Movement PowerJerk = new(28, nameof(PowerJerk));
    public static readonly Movement HangClean = new(29, nameof(HangClean));
    public static readonly Movement HangSnatch = new(30, nameof(HangSnatch));
    public static readonly Movement HangJerk = new(31, nameof(HangJerk));
    public static readonly Movement HangPowerClean = new(32, nameof(HangPowerClean));
    public static readonly Movement HangPowerSnatch = new(33, nameof(HangPowerSnatch));
    public static readonly Movement HangPowerJerk = new(34, nameof(HangPowerJerk));
    public static readonly Movement TurkishGetUp = new(35, nameof(TurkishGetUp));
    public static readonly Movement KettlebellSwing = new(36, nameof(KettlebellSwing));
    public static readonly Movement KettlebellSnatch = new(37, nameof(KettlebellSnatch));
    public static readonly Movement KettlebellClean = new(38, nameof(KettlebellClean));
    public static readonly Movement KettlebellJerk = new(39, nameof(KettlebellJerk));
    public static readonly Movement KettlebellPress = new(40, nameof(KettlebellPress));
    public static readonly Movement KettlebellThruster = new(41, nameof(KettlebellThruster));
    public static readonly Movement KettlebellWindmill = new(42, nameof(KettlebellWindmill));
    public static readonly Movement KettlebellTurkishGetUp =
        new(43, nameof(KettlebellTurkishGetUp));
    public static readonly Movement KettlebellSnatchBalance =
        new(44, nameof(KettlebellSnatchBalance));
    public static readonly Movement KettlebellOverheadSquat =
        new(45, nameof(KettlebellOverheadSquat));
    public static readonly Movement KettlebellFrontSquat = new(46, nameof(KettlebellFrontSquat));
    public static readonly Movement KettlebellBackSquat = new(47, nameof(KettlebellBackSquat));
    public static readonly Movement MuscleUp = new(48, nameof(MuscleUp));
    public static readonly Movement HandstandPushUp = new(49, nameof(HandstandPushUp));
    public static readonly Movement HandstandWalk = new(50, nameof(HandstandWalk));
    public static readonly Movement Pistol = new(51, nameof(Pistol));
    public static readonly Movement Lunge = new(52, nameof(Lunge));
    public static readonly Movement WallWalk = new(53, nameof(WallWalk));
    public static readonly Movement RopeClimb = new(54, nameof(RopeClimb));
    public static readonly Movement ToesToBar = new(55, nameof(ToesToBar));
    public static readonly Movement GhdSitUp = new(56, nameof(GhdSitUp));
    public static readonly Movement GobletSquat = new(57, "Goblet Squat");
    public static readonly Movement DumbbellSnatch = new(58, "Dumbbell Snatch");
    public static readonly Movement DumbbellClean = new(59, "Dumbbell Clean");
    public static readonly Movement DumbbellJerk = new(60, "Dumbbell Jerk");
    public static readonly Movement DumbbellPress = new(61, "Dumbbell Press");
    public static readonly Movement DumbbellThruster = new(62, "Dumbbell Thruster");
    public static readonly Movement FarmersCarry = new(63, "Farmer's Carry");
    public static readonly Movement Plank = new(64, nameof(Plank));

    private Movement(int id, string name)
        : base(id, name) { }

    private Movement(int id, string name, string description)
        : this(id, name)
    {
        Description = description;
    }

    public string Description { get; } = string.Empty;

    public static Movement FromId(int id) => FromValue<Movement>(id);

    public static Movement FromName(string name) => FromDisplayName<Movement>(name);

    public static IEnumerable<Movement> GetAll() => GetAll<Movement>();
}
