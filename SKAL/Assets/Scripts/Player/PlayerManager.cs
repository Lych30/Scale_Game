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
    [SerializeField] TextMeshProUGUI _magicPointsTMP;

    public PlayerBarrel _barrel;

    [SerializeField]float _litresInBlood = 0;
    [SerializeField]float DrunkRatio = 0;
    [SerializeField]private float LerpDrunkRatio = 0;
    [SerializeField] UnityEngine.Rendering.VolumeProfile volumeProfile;
    UnityEngine.Rendering.Universal.DepthOfField DOF;
    UnityEngine.Rendering.Universal.PaniniProjection PP;
    UnityEngine.Rendering.Universal.ChromaticAberration CA;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        _stats.ResetStats();
        UpdateStats();
        ResetVolumeValues();
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
        _magicPointsTMP.text = "Magic Points : " + _stats.magicPoints.ToString();
    }

    
    public void ApplyBlurr()
    {
        if (!volumeProfile.TryGet(out DOF)) throw new System.NullReferenceException(nameof(DOF));
            DOF.focusDistance.Override(2 - (LerpDrunkRatio / (1 + (stats.BlueMagic * 5) * 0.015f)));

        if (!volumeProfile.TryGet(out PP)) throw new System.NullReferenceException(nameof(PP));
            PP.distance.Override(LerpDrunkRatio / (1 + (stats.BlueMagic * 5) * 0.015f));

        if (!volumeProfile.TryGet(out CA)) throw new System.NullReferenceException(nameof(CA));
            CA.intensity.Override(LerpDrunkRatio / (1 + (stats.BlueMagic * 5) * 0.015f));

    }
    public void AddAlcohol(float dose)
    {
        _litresInBlood += dose;

        if (_litresInBlood > stats.tolerance)
        {
            DrunkRatio += 0.1f;
            DrunkRatio = Mathf.Clamp01(DrunkRatio);

            Mathf.Clamp01(DrunkRatio);
        }

    }

    public void FixedUpdate()
    {
        LerpDrunkRatio = Mathf.Lerp(LerpDrunkRatio, DrunkRatio, 0.1f);

        if (_litresInBlood > 0)
            _litresInBlood -= 0.001f * (1 + (stats.BlueMagic * 5) * 0.015f);
        
        if(_litresInBlood < 0)
            _litresInBlood = 0;


        if (DrunkRatio > 0)
            DrunkRatio -= 0.00175f * (1 + (stats.BlueMagic * 5) * 0.015f);

        if (DrunkRatio < 0)
            DrunkRatio = 0;

        LerpDrunkRatio = Mathf.Clamp01(LerpDrunkRatio);

        if (LerpDrunkRatio < 0.01f)
            LerpDrunkRatio = 0f;

        ApplyBlurr();
        
    }

    public void ResetVolumeValues()
    {
        if (!volumeProfile.TryGet(out DOF)) throw new System.NullReferenceException(nameof(DOF));
        DOF.focusDistance.Override(2 );

        if (!volumeProfile.TryGet(out PP)) throw new System.NullReferenceException(nameof(PP));
        PP.distance.Override(0);

        if (!volumeProfile.TryGet(out CA)) throw new System.NullReferenceException(nameof(CA));
        CA.intensity.Override(0);
    }
}
