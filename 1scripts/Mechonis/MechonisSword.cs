using Godot;

namespace Shooter.Mechonis;

public partial class MechonisSword : Node2D
{
    [Export] private int _damage = 1312;
    [Export] public float SwingSpeed = 15f;

    private void OnPlayerEnteredSword(Node2D other)
    {
        Player.Hit(_damage);
    }
}