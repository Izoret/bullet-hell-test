using Godot;

namespace Shooter;

public partial class UI : Control
{
    [Export] private Label _healthLabel;

    private static UI I;

    public override void _Ready()
    {
        I = this;
    }

    public static void UpdateHealthLabel(int hp)
    {
        I._healthLabel.Text = "HP: " + hp + "/" + Player.I.MaxHp;
    }
}