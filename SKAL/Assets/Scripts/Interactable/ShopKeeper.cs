using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject _shopUI;
    public void interact()
    {
        if(_shopUI)
            _shopUI.SetActive(!_shopUI.activeInHierarchy);
    }
}
