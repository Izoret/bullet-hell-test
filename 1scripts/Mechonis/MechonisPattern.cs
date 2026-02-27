namespace Shooter.Mechonis;

public abstract class MechonisPattern(Mechonis mechonis, float duration)
{
    protected readonly Mechonis Mechonis = mechonis;

    public readonly float Duration = duration;
    public MechonisPattern Next;

    public abstract void Trigger();
}