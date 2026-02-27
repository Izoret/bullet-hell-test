using Godot;

namespace Shooter;

public partial class Camera : Camera2D
{
    [Export] public float NoiseShakeSpeed = 30.0f;
    [Export] public float NoiseShakeStrength = 60.0f;
    [Export] public float ShakeDecayRate = 5.0f;

    private FastNoiseLite _noise = new();
    private RandomNumberGenerator _rand = new();

    private float _noiseI;
    private float _shakeStrength;

    public static Camera I;

    public override void _Ready()
    {
        I = this;

        _rand.Randomize();
        _noise.Seed = (int)_rand.Randi();

        _noise.Frequency = 0.5f;
    }

    public void ApplyNoiseShake(float multiplier = 1)
    {
        _shakeStrength = NoiseShakeStrength * multiplier;
    }

    public override void _Process(double delta)
    {
        var fDelta = (float)delta;

        _shakeStrength = Mathf.Lerp(_shakeStrength, 0, ShakeDecayRate * fDelta);
        Offset = GetNoiseOffset(fDelta);
    }

    private Vector2 GetNoiseOffset(float delta)
    {
        _noiseI += delta * NoiseShakeSpeed;

        return new Vector2(
            _noise.GetNoise2D(1, _noiseI) * _shakeStrength,
            _noise.GetNoise2D(100, _noiseI) * _shakeStrength
        );
    }
}