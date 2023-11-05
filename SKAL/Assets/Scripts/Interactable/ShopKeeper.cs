using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject _shopUI;
    [SerializeField] Animator _shopAnimator;
    bool isOpen = false;
    public void interact()
    {

        if (!_shopUI)
            return;

        if (!isOpen)
        {
            OpenShop();
        }
        else
        {
            CloseShop();
        }
             
    }

    public void OpenShop()
    {
        isOpen = true;
        _shopAnimator.Play("Shop_Enter");
        Shop.instance.LoadShop();
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = false;
    }

    public void CloseShop()
    {
        isOpen = false;
        _shopAnimator.Play("Shop_Exit");
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = true;
        StartCoroutine(Shop.instance.UnLoadShop());
    }
}
