using System;
using Godot;

namespace Shooter;

public partial class Mechonis : Area2D
{
    [Export] private float _maxHealth = 100f;
    private float _currentHealth;

    private const float ShootingCooldownMs = 200f;
    private static float _lastShootTimeStamp;

    public override void _Ready()
    {
        _currentHealth = _maxHealth;
    }

    public override void _Process(double delta)
    {
        if (_lastShootTimeStamp + ShootingCooldownMs > Time.GetTicksMsec()) return;

        var towards = new Vector2(Player.I.Position.X - Position.X, Player.I.Position.Y - Position.Y);
        EnemyBullet.SpawnOne(Position, towards);

        _lastShootTimeStamp = Time.GetTicksMsec();
    }

    private void OnAreaEntered(Area2D other)
    {
        // physics layers only detect player bullets

        GD.Print("smth entered");

        LoseHealth();
    }

    private void LoseHealth()
    {
        _currentHealth -= PlayerBullet.Damage;
        if (_currentHealth <= 0f) Die();
    }

    private void Die()
    {
        GD.Print("arglas wins!");
        QueueFree();
    }
}