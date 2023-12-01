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
    [SerializeField] GameObject _centralCrystal;
    [SerializeField] Button[] buttons;
    /*
     rouge = % de capacité en plus
     vert = % de reduction de l'effet de l'alcool
     bleu = % de taille du QTE
    */
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;

    }

    public void EnableButtons(bool enable)
    {
        foreach (var button in buttons)
            button.interactable = enable;
    }


    public void AddMagic(int color)
    {
        if (PlayerManager.instance.stats.magicPoints <= 0)
            return;

        MagicSlider slider = new MagicSlider();

        switch (color)
        {
            case 2: slider = _blueSlider;

                    if (slider.Maxed)
                        return;

                    PlayerMagic.instance.AddBluePower();
                break;

            case 3:
                slider = _greenSlider;

                if (slider.Maxed)
                    return;

                PlayerMagic.instance.AddGreenPower();
                break;

            case 1:
                slider = _redSlider;

                if (slider.Maxed)
                    return;

                PlayerMagic.instance.AddRedPower();
                break;

            default:
                slider = _redSlider;

                if (slider.Maxed)
                    return;

                PlayerMagic.instance.AddRedPower();
                break;
        }

        PlayerManager.instance.stats.magicPoints--;
        PlayerManager.instance.UpdateStats();
        SoundManager.instance.PlaySFX("magic");

        slider.value += 1;

        if (slider.value >= slider.maxValue)
        {
            slider.maxValue = slider.value;
            slider.Maxed = true;
        }

        if(_redSlider.Maxed && _blueSlider.Maxed && _greenSlider.Maxed)
            _centralCrystal.SetActive(true);
    }

    public void PlaySelectSound()
    {
        SoundManager.instance.PlaySFX("Button_Selected");
    }


}
