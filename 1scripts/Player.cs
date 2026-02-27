using System;
using Godot;

namespace Shooter;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 600;

	public static Player I;
	public override void _Ready()
	{
		I = this;
	}

	public void SetDirection(Vector2 dir)
	{
		Velocity = dir * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
}
