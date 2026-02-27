using Godot;

namespace Shooter.Mechonis;

public class MechonisPatternHandler
{
    private MechonisPattern _currentState;
    private float _stateSwitchTimestamp;

    public MechonisPatternHandler(Mechonis mechonis)
    {
        var shootingLots = new MechonisShoot(mechonis, 2500);
        var smallSlash = new MechonisSlash(mechonis, 300);
        var shootingBig = new MechonisShoot(mechonis, 2500, bulletSizeMul: 3, cooldownMs: 400);
        var longSlash = new MechonisSlash(mechonis, 1200);
        //var resting = new MechonisRest(mechonis, 700);

        shootingLots.Next = smallSlash;
        smallSlash.Next = shootingBig;
        shootingBig.Next = longSlash;
        longSlash.Next = shootingLots;

        _currentState = shootingLots;

        _stateSwitchTimestamp = Time.GetTicksMsec();
    }

    public void Act()
    {
        if (Time.GetTicksMsec() > _stateSwitchTimestamp + _currentState.Duration)
        {
            _currentState = _currentState.Next;
            _stateSwitchTimestamp = Time.GetTicksMsec();
        }

        _currentState.Trigger();
    }
}