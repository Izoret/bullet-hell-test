using Godot;

namespace Shooter.Mechonis;

public partial class Mechonis : Area2D
{
    [Export] public MechonisSword Sword;

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

    // physics layers only detect player bullets
    private void OnAreaEntered(Area2D other)
    {
        LoseHealth();

        var vfx = Manager.I.VFX.Instantiate<GpuParticles2D>();
        vfx.GlobalPosition = other.GlobalPosition;
        GetTree().CurrentScene.AddChild(vfx);

        other.GetParent().QueueFree();
    }

    private void LoseHealth()
    {
        _currentHealth -= PlayerBullet.Damage;
        if (_currentHealth <= 0f) Die();
    }

    private void Die()
    {
        GD.Print("arglas wins!");
        SpeedrunTimer.StopTimer();
        QueueFree();
    }
}