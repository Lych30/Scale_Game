using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    IInteractable _interactable;
    public bool CanInteract = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable TempInteractable = collision.GetComponent<IInteractable>();

        if (TempInteractable == null || TempInteractable == _interactable)
            return;

        _interactable = collision.GetComponent<IInteractable>();
        _interactable.ShowAnnotation();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_interactable != null)
            _interactable.HideAnnotation();

        _interactable = null;
    }

    public void TryInteract(InputAction.CallbackContext context)
    {
        if(!CanInteract)
            return;

        if(!context.performed) return;

        if (_interactable == null)
            return;

        _interactable.interact();
    }
}
