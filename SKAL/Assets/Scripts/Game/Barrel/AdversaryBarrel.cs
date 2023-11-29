using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;


public class AdversaryBarrel : Barrel
{
    AdversaryStats _adversaryStats;
    public override void Init(int litres, AdversaryStats stats, Slider slider, Difficulty difficulty)
    {
        _LitresToDring  = litres;
        _adversaryStats = stats;
        _slider = slider;
        SetUpSliderValues();
        SetUpVisuals(difficulty);
        
    }

    public override void Sip()
    {
        _LitresToDring -= _adversaryStats.capacity;
        UpdateLitresText();
        _slider.value = _LitresToDring * 20;

        if (_LitresToDring > 0)
            return;

        StartCoroutine(GameManager.instance.GameEnd(false));
        //UPDATE VISUALS
    }

    protected override void SetUpVisuals(Difficulty difficulty)
    {
        base.SetUpVisuals(difficulty);
    }

    
}
