using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerBarrel : Barrel
{
    PlayerStats _playerStats;
    

    public override void Init(int litres, PlayerStats stats, Slider slider,Difficulty difficulty)
    {
        _LitresToDring = litres;
        _playerStats = stats;
        _slider = slider;
        SetUpVisuals(difficulty);
        SetUpSliderValues();
    }

    public override void Sip()
    {
        float sipValue = _playerStats.capacity * (1 + ((PlayerManager.instance.stats.RedMagic * 5) * 0.01f));
        _LitresToDring -= sipValue;

        PlayerManager.instance.AddAlcohol(sipValue);

        _slider.value = _LitresToDring * 20;

        if (_LitresToDring <= 0)
            StartCoroutine(GameManager.instance.GameEnd(true));
        //UPDATE VISUALS
    }

    protected override void SetUpVisuals(Difficulty difficulty)
    {
        base.SetUpVisuals(difficulty);
    }

}
