using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatsMenu : MonoBehaviour
{
    StatsMenu menu;
    bool IsOpen = false;
    private void Start()
    {
        menu = FindObjectOfType<StatsMenu>();
    }
    public void OnOpenStats(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        IsOpen = !IsOpen;

        if (IsOpen)
            menu.OpenMenu();
        else
            menu.CloseMenu();
    }
}
