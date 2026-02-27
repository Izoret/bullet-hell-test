using Godot;

namespace Shooter;

public partial class PlayerBullet : Node2D
{
    private float _speed = 800f;

    public const float Damage = 10f;

    private const float TimeToLiveMs = 1000f;
    private float _timeWhenSpawned;

    private const float ShootingCooldownMs = 200f;
    private static float _lastShootTimeStamp;

    private static readonly PackedScene BulletScene = GD.Load<PackedScene>("res://0scenes/player_bullet.tscn");

    public override void _Ready()
    {
    }

    public override void _PhysicsProcess(double delta)
    {
        GoUp(delta);

        if (Time.GetTicksMsec() > _timeWhenSpawned + TimeToLiveMs)
            QueueFree();
    }

    private void GoUp(double delta)
    {
        var dir = new Vector2
        {
            Y = (float)(-_speed * delta)
        };
        Position += dir;
    }

    public static void AskToSpawn()
    {
        if (_lastShootTimeStamp + ShootingCooldownMs > Time.GetTicksMsec()) return;

        SpawnOne();

        _lastShootTimeStamp = Time.GetTicksMsec();
    }

    private static void SpawnOne()
    {
        if (BulletScene.Instantiate() is not PlayerBullet newBullet) return;
        Manager.I.PlayerBullets.AddChild(newBullet);

        newBullet.Position = Player.I.Position;
        newBullet._timeWhenSpawned = Time.GetTicksMsec();
    }
}