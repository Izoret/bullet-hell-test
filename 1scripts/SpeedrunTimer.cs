using System;
using Godot;

namespace Shooter;

public partial class SpeedrunTimer : Label
{
    private static SpeedrunTimer I;

    public override void _Ready()
    {
        I = this;

        StartTimer();
    }

    private double _timeElapsed = 0.0;
    private bool _isRunning = false;

    public override void _Process(double delta)
    {
        if (_isRunning)
        {
            _timeElapsed += delta;
            Text = FormatTime(_timeElapsed);
        }
    }

    private string FormatTime(double time)
    {
        TimeSpan ts = TimeSpan.FromSeconds(time);
        return ts.ToString(@"mm\:ss\.fff");
    }

    public static void StartTimer() => I._isRunning = true;
    public static void StopTimer() => I._isRunning = false;

    public static void ResetTimer()
    {
        I._timeElapsed = 0;
        I.Text = "00:00.000";
    }
}