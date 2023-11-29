using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsMenu : MonoBehaviour
{
    ControlsMenu menu;
    bool IsOpen = false;
    private void Start()
    {
        menu = ControlsMenu.instance;
    }
    public void OnOpenControls(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        IsOpen = !IsOpen;

        if (IsOpen)
            menu.OpenMenu();
        else
            menu.CloseMenu();
    }
}
