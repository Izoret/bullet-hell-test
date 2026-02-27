using System;
using Godot;

namespace Shooter;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed = 600;

    [Export] public int MaxHp = 4791;
    private int _hp;

    public static Player I;

    public override void _Ready()
    {
        I = this;

        _hp = MaxHp;
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
    
    public static void SetDirection(Vector2 dir)
    {
        I.Velocity = dir * I.Speed;
    }


    public static void Hit(int damage)
    {
        Camera.I.ApplyNoiseShake();
        I._hp -= damage;
        UI.UpdateHealthLabel(I._hp);
        if (I._hp <= 0) I.Die();
    }

    private void Die()
    {
        GD.Print("arglas est mort.....");
    }
}