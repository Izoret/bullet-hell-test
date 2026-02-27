using Godot;

namespace Shooter;

public partial class HitVfx : GpuParticles2D
{
    public override void _Ready()
    {
        Emitting = true;
        Finished += QueueFree;
    }
}