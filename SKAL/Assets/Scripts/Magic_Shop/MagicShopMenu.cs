using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class MagicShopMenu : MonoBehaviour
{
    public static MagicShopMenu instance;
    [SerializeField] private MagicSlider _redSlider;
    [SerializeField] private MagicSlider _greenSlider;
    [SerializeField] private MagicSlider _blueSlider;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;

    }

    public void AddMagic(int color)
    {
        MagicSlider slider = new MagicSlider();

        switch (color)
        {
            case 2:
                PlayerMagic.instance.AddBluePower();
                slider = _blueSlider;
                break;

            case 3:
                PlayerMagic.instance.AddGreenPower();
                slider = _greenSlider;
                break;

            case 1:
                PlayerMagic.instance.AddRedPower();
                slider = _redSlider;
                break;

            default:
                PlayerMagic.instance.AddRedPower();
                slider = _redSlider;
                break;
        }

        if (slider.Maxed)
            return;

        slider.value += 1;

        if (slider.value > slider.maxValue)
        {
            slider.maxValue = slider.value;
            slider.Maxed = true;
        }
    }

    
}
