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

    public override void Init()
    {
        _scaleToSucceed = GameManager.instance.precisionAmount * (1 + ((PlayerManager.instance.stats.BlueMagic * 5) * 0.01f));

        base.Init();


    }

    protected override void HandleCircleSpeedAndStreak()
    {
        _circleSpeed += 0.15f;
        if (_circleSpeed > _maxCircleSpeed * (1 + ((PlayerManager.instance.stats.RedMagic * 5) * 0.01f)))
            _circleSpeed = _maxCircleSpeed * (1 + ((PlayerManager.instance.stats.RedMagic * 5) * 0.01f));

        streak++;

        if (streak > 4)
            streak = 4;
    }
}
