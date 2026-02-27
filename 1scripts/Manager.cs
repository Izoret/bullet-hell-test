using Godot;

namespace Shooter;

public partial class Manager : Node2D
{
	[Export] public Node PlayerBullets;
	[Export] public Node EnemyBullets;

	public static Manager I;
	public override void _Ready()
	{
		I = this;
	}

	public override void _Process(double delta)
	{
		Vector2 dir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Player.I.SetDirection(dir);
		
		if (Input.IsActionPressed("ui_accept")) PlayerBullet.AskToSpawn();
	}
}