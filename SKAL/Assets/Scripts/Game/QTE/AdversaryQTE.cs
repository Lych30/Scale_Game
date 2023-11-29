using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryQTE : QTE
{

    public override bool Try()
    {
        if (GetCorrectScale(_progression) <= _scaleToSucceed)
        {
            HandleVisualEffect();
            HandleCircleSpeedAndStreak();
            ResetQTE();
            return true;
        }
        else
        {
            streak = 0;
            _circleSpeed = 1;
            ResetQTE();
            return false;
        }
    }

    public override void Init()
    {
        _scaleToSucceed = GameManager.instance.precisionAmount;
        base.Init();
        
    }

    protected override void HandleCircleSpeedAndStreak()
    {
        base.HandleCircleSpeedAndStreak();
    }


}
