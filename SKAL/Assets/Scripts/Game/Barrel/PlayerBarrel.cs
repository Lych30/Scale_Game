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
        Debug.Log(_LitresToDring);

        _slider.value = _LitresToDring * 20;

        if (_LitresToDring <= 0)
            GameManager.instance.Win(_playerStats.name);
        //UPDATE VISUALS
    }
}
