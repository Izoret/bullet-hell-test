using Godot;

namespace Shooter.Mechonis;

public class MechonisPatternDurationShoot(float duration, float bulletSizeMul = 1, int cooldownMs = 200)
    : MechonisPatternDuration(duration)
{
    private float _lastShootTimeStamp;

    protected override void TriggerAction()
    {
        if (_lastShootTimeStamp + cooldownMs > Time.GetTicksMsec()) return;

        var direction = new Vector2(Player.I.Position.X - Mechonis.Position.X,
            Player.I.Position.Y - Mechonis.Position.Y);
        EnemyBullet.SpawnOne(from: Mechonis.Position, towards: direction, sizeMultiplier: bulletSizeMul);

        _lastShootTimeStamp = Time.GetTicksMsec();
    }
}