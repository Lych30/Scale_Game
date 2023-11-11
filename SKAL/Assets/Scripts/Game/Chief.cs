using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Chief : MonoBehaviour, IInteractable
{
    public static Chief instance;
    [SerializeField] GameObject _GSelectionUI;
    [SerializeField] Animator _GSelectionAnimator;
    bool isOpen = false;
    bool _isAnimFinished = true;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;

    }
    public void interact()
    {

        if (!_GSelectionUI)
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
        _GSelectionAnimator.Play("GS_Enter");
        GameSelectionMenu.instance.OpenMenu();
        GameSelectionMenu.instance.SetButtonInteractability(true);
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = false;
    }

    public void CloseShop()
    {
        isOpen = false;
        _GSelectionAnimator.Play("GS_Exit");
        GameSelectionMenu.instance.SetButtonInteractability(false);
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = true;
    }

    IEnumerator canInteractChange()
    {
        yield return new WaitForSeconds(1.0f);
        _isAnimFinished = true;
    }
}
