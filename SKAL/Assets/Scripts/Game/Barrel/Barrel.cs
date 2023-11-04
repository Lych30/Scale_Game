using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrel : MonoBehaviour
{
    [SerializeField] protected float _LitresToDring;
    [SerializeField] protected Slider _slider;
    public virtual void Init(int litres, PlayerStats stats, Slider slider)
    {
    }

    public virtual void Init(int litres, AdversaryStats stats, Slider slider)
    {
    }

    public virtual void Sip()
    {
    }

    public void SetUpSliderValues()
    {
        _slider.minValue = 0;
        _slider.maxValue = _LitresToDring * 20;
        _slider.value = _slider.maxValue;
    }
}
