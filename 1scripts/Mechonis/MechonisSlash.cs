namespace Shooter.Mechonis;

public class MechonisSlash(Mechonis mechonis, float duration) : MechonisPattern(mechonis, duration)
{
    public override void Trigger()
    {
        Mechonis.Sword.Rotate(-0.1f);
    }
}