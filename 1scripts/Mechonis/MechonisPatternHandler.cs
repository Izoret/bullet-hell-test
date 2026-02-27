using Godot;

namespace Shooter.Mechonis;

public class MechonisPatternHandler
{
    private MechonisPattern _currentState;
    private float _stateSwitchTimestamp;

    public MechonisPatternHandler(Mechonis mechonis)
    {
        var shooting = new MechonisShoot(mechonis, 2500);
        var resting = new MechonisRest(mechonis, 700);
        var slashing = new MechonisSlash(mechonis, 400);

        shooting.Next = resting;
        resting.Next = slashing;
        slashing.Next = shooting;

        _currentState = shooting;

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