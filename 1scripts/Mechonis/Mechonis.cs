using Godot;

namespace Shooter.Mechonis;

public partial class Mechonis : Area2D
{
    [Export] public Node2D Sword;

    [Export] private float _maxHealth = 100f;
    private float _currentHealth;

    private MechonisPatternHandler _stateMachine;

    public override void _Ready()
    {
        _stateMachine = new MechonisPatternHandler(this);

        _currentHealth = _maxHealth;
    }

    public override void _Process(double delta)
    {
        _stateMachine.Act();
    }

    private void OnAreaEntered(Area2D other)
    {
        // physics layers only detect player bullets

        LoseHealth();
    }

    private void OnPlayerEnteredSword(Node2D other)
    {
        GD.Print("OUCH");
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