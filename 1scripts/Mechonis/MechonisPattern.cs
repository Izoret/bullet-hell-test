namespace Shooter.Mechonis;

public abstract class MechonisPattern
{
    public Mechonis Mechonis;

    public MechonisPattern Next;

    public abstract void Trigger();
    public abstract bool Finished();
}