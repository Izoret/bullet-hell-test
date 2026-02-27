using Godot;

namespace Shooter.Mechonis;

public class MechonisShoot(
    Mechonis mechonis,
    float duration,
    float bulletSizeMul = 1,
    int cooldownMs = 200
    ) : MechonisPattern(mechonis, duration)
{
    private static float _lastShootTimeStamp;

    public override void Trigger()
    {
        if (_lastShootTimeStamp + cooldownMs > Time.GetTicksMsec()) return;

        var direction = new Vector2(Player.I.Position.X - Mechonis.Position.X,
            Player.I.Position.Y - Mechonis.Position.Y);
        EnemyBullet.SpawnOne(from: Mechonis.Position, towards: direction, sizeMultiplier: bulletSizeMul);

        _lastShootTimeStamp = Time.GetTicksMsec();
    }
}