using System;
using Godot;

namespace Shooter;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed = 600;

    [Export] public int MaxHp = 5;
    private int _hp;

    public static Player I;

    public override void _Ready()
    {
        I = this;

        _hp = MaxHp;
    }

    public void SetDirection(Vector2 dir)
    {
        Velocity = dir * Speed;
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    public void GetHit()
    {
        GD.Print("i got hit!!");
        _hp--;
        if (_hp <= 0) Die();
    }

    private void Die()
    {
        GD.Print("arglas est mort.....");
    }
}