using System;
using System.Collections.Generic;
using Godot;

namespace Shooter.Mechonis;

public class PatternsHandler
{
    private MechonisPattern _currentState;

    public PatternsHandler(Mechonis mechonis)
    {
        InitializePatterns(mechonis, [
            new MechonisPatternDurationShoot(2500),
            new MechonisPatternDurationRest(300),
            new MechonisPatternConditionSlash(180),
            new MechonisPatternDurationRest(300),
            new MechonisPatternDurationShoot(2500, bulletSizeMul: 2.5f, cooldownMs: 410),
            new MechonisPatternConditionSlash(648)
        ]);
    }

    public void Act()
    {
        _currentState.Trigger();

        if (_currentState.Finished())
        {
            _currentState = _currentState.Next;
        }
    }

    private void InitializePatterns(Mechonis mechonis, List<MechonisPattern> patterns)
    {
        for (var i = 0; i < patterns.Count; i++)
        {
            MechonisPattern pattern = patterns[i];
            pattern.Mechonis = mechonis;
            pattern.Next = patterns[(i + 1) % patterns.Count];
        }

        _currentState = patterns[new Random().Next(patterns.Count)];
    }
}