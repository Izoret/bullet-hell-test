using System;
using Godot;

namespace Shooter;

public partial class Mechonis : Area2D
{
    [Export] private float _maxHealth = 100f;
    private float _currentHealth;

    public override void _Ready()
    {
        _currentHealth = _maxHealth;
    }

    public override void _Process(double delta)
    {
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