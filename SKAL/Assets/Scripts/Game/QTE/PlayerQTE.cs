using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQTE : QTE
{

    public override bool Try()
    {
        if (GetCorrectScale(_progression) <= _scaleToSucceed)
        {
            HandleVisualEffect();
            HandleCircleSpeedAndStreak();
            Init();
            return true;
        }
        else
        {
            streak = 0;
            _circleSpeed = 1;
            Init();
            return false;
        }
    }
}
