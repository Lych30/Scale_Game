using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class GameSelectionMenu : MonoBehaviour
{
    public static GameSelectionMenu instance;
    [SerializeField] Button _launchButton;
    [SerializeField] Button _CloseButton;
    [SerializeField] TextMeshProUGUI _aName;
    [SerializeField] TextMeshProUGUI _aTitle;
    [SerializeField] TextMeshProUGUI _aCapacity;
    [SerializeField] TextMeshProUGUI _aDifficulty;
    AdversaryStats _stats;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;

    }



    public void Init(AdversaryStats stats)
    {
        _stats = stats;
        _aName.text = _stats.name;
        _aTitle.text = _stats.title;
        _aCapacity.text = "CAPACITY : " + _stats.capacity.ToString() +"L PER SIP";

        string dif = GameManager.instance.litreToDrink + "L DUEL";
        _aDifficulty.text = dif;

    }


    public void LaunchGame()
    {
        StartCoroutine(LaunchGameCoroutine());
    }

    public void OpenMenu()
    {
        ESReference.instance.eventSystem.SetSelectedGameObject(_launchButton.gameObject);
    }

    public void CloseMenu()
    {
        Chief.instance.CloseShop();
    }


    public void SetButtonInteractability(bool canBeInteractedWith)
    {
        _launchButton.interactable = canBeInteractedWith;
        _CloseButton.interactable = canBeInteractedWith;
    }

    public IEnumerator LaunchGameCoroutine()
    {
        Chief.instance.CloseShop();
        yield return new WaitForSeconds(0.8f);
        GameManager.instance.SetUpGame();
    }
    
}
