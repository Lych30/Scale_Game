using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    IInteractable _interactable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable TempInteractable = collision.GetComponent<IInteractable>();

        if (TempInteractable == null || TempInteractable == _interactable)
            return;

        _interactable = collision.GetComponent<IInteractable>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactable = null;
    }

    public void TryInteract(InputAction.CallbackContext context)
    {
        if(!context.performed) return;

        if (_interactable == null)
            return;

        if (Input.GetKeyDown(KeyCode.F))
            _interactable.interact();
    }
}
