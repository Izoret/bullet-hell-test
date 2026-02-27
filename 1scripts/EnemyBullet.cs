using Godot;

namespace Shooter;

public partial class EnemyBullet : Node2D
{
    private float _speed = 600f;
    private Vector2 _direction;
    private int _damage = 702;

    private const float TimeToLiveMs = 1500f;
    private float _timeWhenSpawned;

    private static readonly PackedScene BulletScene = GD.Load<PackedScene>("res://0scenes/enemy_bullet.tscn");

    public override void _PhysicsProcess(double delta)
    {
        GoTowards(delta);

        if (Time.GetTicksMsec() > _timeWhenSpawned + TimeToLiveMs)
            QueueFree();
    }

    private void GoTowards(double delta)
    {
        Position += _direction * _speed * (float)delta;
    }

    private void OnPlayerHit(Node2D other)
    {
        Player.Hit(_damage);
        QueueFree();
    }

    public static void SpawnOne(Vector2 from, Vector2 towards)
    {
        if (BulletScene.Instantiate() is not EnemyBullet newBullet) return;
        Manager.I.EnemyBullets.AddChild(newBullet);

        newBullet.Position = from;
        newBullet._direction = towards.Normalized();
        newBullet._timeWhenSpawned = Time.GetTicksMsec();
    }
}