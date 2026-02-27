namespace Shooter.Mechonis;

public class MechonisPatternConditionSlash(float degrees = 360) : MechonisPatternCondition
{
    private float _totalRotated = 0;

    public override void Trigger()
    {
//        Mechonis.Sword.Rotate(-0.01f * Mechonis.Sword.SwingSpeed);

        const int degree = 6;

        Mechonis.Sword.RotationDegrees -= degree;
        _totalRotated += degree;
    }

    public override bool Finished()
    {
        if (_totalRotated >= degrees)
        {
            _totalRotated -= degrees;
            return true;
        }

        return false;
    }
}