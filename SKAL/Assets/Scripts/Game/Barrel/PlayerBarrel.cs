using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarrel : Barrel
{
    PlayerStats _playerStats;
    public override void Init(int litres, PlayerStats stats, Slider slider)
    {
        _LitresToDring = litres;
        _playerStats = stats;
        _slider = slider;
        SetUpSliderValues();
    }

    public override void Sip()
    {
        _LitresToDring -= _playerStats.capacity;

        _slider.value = _LitresToDring * 20;

        if (_LitresToDring <= 0)
            GameManager.instance.GameEnd(true);
        //UPDATE VISUALS
    }
}
