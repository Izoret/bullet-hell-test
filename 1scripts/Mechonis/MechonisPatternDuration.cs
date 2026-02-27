using Godot;

namespace Shooter.Mechonis;

public abstract class MechonisPatternDuration(float duration) : MechonisPattern
{
    private float _stateStartTimestamp = 0;

    public override void Trigger()
    {
        if (_stateStartTimestamp == 0) _stateStartTimestamp = Time.GetTicksMsec();
        TriggerAction();
    }

    protected abstract void TriggerAction();

    public override bool Finished()
    {
        if (Time.GetTicksMsec() > _stateStartTimestamp + duration)
        {
            _stateStartTimestamp = 0;
            return true;
        }
        return false;
    }
}