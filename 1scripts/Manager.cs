using Godot;

namespace Shooter;

public partial class Manager : Node2D
{
    [Export] public Node PlayerBullets;
    [Export] public Node EnemyBullets;
    [Export] public PackedScene VFX;
    [Export] public Node Enemies;

    public static Manager I;

    public override void _Ready()
    {
        I = this;
    }

    public override void _Process(double delta)
    {
        Vector2 dir = Input.GetVector("Left", "Right", "Up", "Down");
        Player.SetDirection(dir);

        if (Input.IsActionPressed("Space")) PlayerBullet.AskToSpawn();

        HandleGameWin();
    }

    private void HandleGameWin()
    {
        if (Enemies.GetChildCount() == 0)
        {
            GD.Print("arglas wins!");
            SpeedrunTimer.StopTimer();
        }
    }
}