using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInteract))]
[RequireComponent(typeof(PlayerInteract))]
[RequireComponent(typeof(PlayerCoins))]
[RequireComponent(typeof(PlayerMagic))]
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private PlayerStats _stats;
    public PlayerStats stats { get { return _stats; } }

    [Header("STATS UI")]
    [SerializeField] TextMeshProUGUI _capacityTMP;
    [SerializeField] TextMeshProUGUI _toleranceTMP;
    [SerializeField] TextMeshProUGUI _currencyTMP;
    [SerializeField] TextMeshProUGUI _magicPointsTMP;

    public PlayerBarrel _barrel;
    public PlayerStats Stats { get { return _stats; } }

    [SerializeField] float _litresInBlood = 0;
    float DrunkRatio = 0;
    [SerializeField] private float LerpDrunkRatio = 0;
    [SerializeField] UnityEngine.Rendering.VolumeProfile volumeProfile;
    UnityEngine.Rendering.Universal.DepthOfField DOF;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        _stats.tolerance = _stats.BaseTolerance;
        _stats.capacity = _stats.BaseCapacity;
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
        _currencyTMP.text = "currency : " + _stats.currency.ToString();
        _magicPointsTMP.text = "Magic Points : " + _stats.magicPoints.ToString();

      
    }

    
    public void ApplyBlurr()
    {
        if (!volumeProfile.TryGet(out DOF)) throw new System.NullReferenceException(nameof(DOF));
        DOF.focusDistance.Override(2 - LerpDrunkRatio);

    }
    public void AddAlcohol(float dose)
    {
        _litresInBlood += dose;

        if (_litresInBlood > stats.tolerance)
        {
            DrunkRatio += 0.1f;
            Mathf.Clamp01(DrunkRatio);
        }

    }

    public void FixedUpdate()
    {
        LerpDrunkRatio = Mathf.Lerp(LerpDrunkRatio, DrunkRatio, 0.1f);

        if (_litresInBlood > 0)
            _litresInBlood -= 0.001f;
        
        if(_litresInBlood < 0)
            _litresInBlood = 0;
       

        if(DrunkRatio > 0)
            DrunkRatio -= 0.001f;

        if (DrunkRatio < 0)
            DrunkRatio = 0;

        ApplyBlurr();
        
    }
}
