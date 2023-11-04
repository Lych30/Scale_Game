using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AdversaryBarrel : Barrel
{
    AdversaryStats _adversaryStats;
    public override void Init(int litres, AdversaryStats stats, Slider slider)
    {
        _LitresToDring  = litres;
        _adversaryStats = stats;
        _slider = slider;
        SetUpSliderValues();
    }

    public override void Sip()
    {
        _LitresToDring -= _adversaryStats.capacity;
        _slider.value = _LitresToDring * 20;
        if (_LitresToDring <= 0)
            GameManager.instance.Loose(_adversaryStats.name);
        //UPDATE VISUALS
    }
}
