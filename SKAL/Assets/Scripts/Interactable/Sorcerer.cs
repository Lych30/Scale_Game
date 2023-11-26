using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : MonoBehaviour, IInteractable
{
    [SerializeField] MagicShopMenu _magicShopUI;
    [SerializeField] Animator _magicShopAnimator;
    [SerializeField] GameObject _annotation;
    [SerializeField] GameObject _selectedButton;
    bool isOpen = false;
    bool _isAnimFinished = true;
    public void interact()
    {

        if (!_magicShopUI)
            return;

        if (!_isAnimFinished)
            return;

        _isAnimFinished = false;

        if (!isOpen)
        {
            OpenShop();
        }
        else
        {
            CloseShop();
        }

        StartCoroutine(canInteractChange());
    }

    public void OpenShop()
    {
        isOpen = true;
        _magicShopAnimator.Play("MagicShop_Enter");
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = false;

        MagicShopMenu.instance.EnableButtons(true);
        if (_selectedButton)
            ESReference.instance.eventSystem.SetSelectedGameObject(_selectedButton);
    }

    public void CloseShop()
    {
        isOpen = false;
        _magicShopAnimator.Play("MagicShop_Exit");
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = true;
        StartCoroutine(waitToenable());
    }

    public IEnumerator waitToenable()
    {
        yield return new WaitForSeconds(1f);
        MagicShopMenu.instance.EnableButtons(false);
    }
    IEnumerator canInteractChange()
    {
        yield return new WaitForSeconds(1.0f);
        _isAnimFinished = true;
    }

    public void ShowAnnotation()
    {
        _annotation.SetActive(true);
    }

    public void HideAnnotation()
    {
        _annotation.SetActive(false);
    }
}
