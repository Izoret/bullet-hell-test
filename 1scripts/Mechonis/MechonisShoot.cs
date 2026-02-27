using Godot;

namespace Shooter.Mechonis;

public class MechonisShoot(Mechonis mechonis, float duration) : MechonisPattern(mechonis, duration)
{
    private const float ShootingCooldownMs = 200f;
    private static float _lastShootTimeStamp;

    public override void Trigger()
    {
        if (_lastShootTimeStamp + ShootingCooldownMs > Time.GetTicksMsec()) return;

        var direction = new Vector2(Player.I.Position.X - Mechonis.Position.X,
            Player.I.Position.Y - Mechonis.Position.Y);
        EnemyBullet.SpawnOne(from: Mechonis.Position, towards: direction);

        _lastShootTimeStamp = Time.GetTicksMsec();
    }
}