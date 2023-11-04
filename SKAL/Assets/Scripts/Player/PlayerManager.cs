using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement),typeof(PlayerInteract),typeof(PlayerCoins))]
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private PlayerStats _stats;

    [Header("STATS UI")]
    [SerializeField] TextMeshProUGUI _capacityTMP;
    [SerializeField] TextMeshProUGUI _toleranceTMP;

    public PlayerBarrel _barrel;
    public PlayerStats Stats { get { return _stats; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        UpdateStats();
    }

    public void TryQTE(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (!GameManager.instance.gameActive)
            return;

        if (GameManager.instance.playerQTE.Try())
        {
            _barrel.Sip();
        }

    }

    public void UpdateStats()
    {
        _capacityTMP.text = "Capacity : " + _stats.capacity.ToString();
        _toleranceTMP.text = "Tolerance : " + _stats.tolerance.ToString();
    }

}
