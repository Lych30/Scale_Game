using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Barrel : MonoBehaviour
{
    [SerializeField] protected float _LitresToDring;
    [SerializeField] protected Slider _slider;
    [SerializeField] protected GameObject[] _visuals;
    [SerializeField] protected TextMeshProUGUI _litresTMPRo;
    private GameObject _currentVisual;
    public virtual void Init(int litres, PlayerStats stats, Slider slider, Difficulty difficulty)
    {
    }

    public virtual void Init(int litres, AdversaryStats stats, Slider slider, Difficulty difficulty)
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
        UpdateLitresText();
    }

    protected virtual void SetUpVisuals(Difficulty difficulty)
    {
        if (_visuals.Count() < 4)
            return;

        for (int i = 0; i < _visuals.Count(); i++)
        {
            if ((int)difficulty != i)
            {
                _visuals[i].SetActive(false);
                continue;
            }

            _visuals[i].SetActive(true);
            _currentVisual = _visuals[i];
        }
    }

    public void DisableVisual()
    {
        _currentVisual.SetActive(false);
    }

    public void UpdateLitresText()
    {
        if(_litresTMPRo)
            _litresTMPRo.text = Math.Round(_LitresToDring,2).ToString() +"L";
    }

    public void ResetTMProTexts()
    {
        _litresTMPRo.text = "";
    }
}
