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
            HandleSound();
            ResetQTE();
            return true;
        }
        else
        {
            SoundManager.instance.PlaySFX("Fail");
            streak = 0;
            _circleSpeed = 1;
            ResetQTE();
            return false;
        }
    }

    public override void Init()
    {
        _scaleToSucceed = GameManager.instance.precisionAmount * (1 + ((PlayerManager.instance.stats.GreenMagic * 5) * 0.01f));

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

        Debug.Log(_circleSpeed);
    }
}
