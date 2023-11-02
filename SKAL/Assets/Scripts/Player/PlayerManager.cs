using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement),typeof(PlayerInteract),typeof(PlayerCoins))]
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private PlayerStats _stats;
    public PlayerStats Stats { get { return _stats; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    public void TryQTE(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (!GameManager.instance.gameActive)
            return;

        GameManager.instance.playerQTE.Try();
        
    }

}
