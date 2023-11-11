using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageChief : MonoBehaviour, IInteractable
{
    

    [SerializeField] GameObject _shopUI;
    [SerializeField] Animator _shopAnimator;
    bool isOpen = false;
    bool _isAnimFinished = true;
    public void interact()
    {

        if (!_shopUI)
            return;

        if (!_isAnimFinished)
            return;

        _isAnimFinished = false;

        if (!isOpen)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }

        StartCoroutine(canInteractChange());
    }

    IEnumerator canInteractChange()
    {
        yield return new WaitForSeconds(1.0f);
        _isAnimFinished = true;
    }

    public void OpenMenu()
    {
        isOpen = true;
        _shopAnimator.Play("Menu_Enter");
        Shop.instance.LoadShop();
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = false;
    }

    public void CloseMenu()
    {
        isOpen = false;
        _shopAnimator.Play("Menu_Exit");
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = true;
        StartCoroutine(Shop.instance.UnLoadShop());
    }
}
