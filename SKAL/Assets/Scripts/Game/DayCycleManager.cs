using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayCycleManager : MonoBehaviour
{
    public static DayCycleManager instance;

    [Header("GLOBAL ILLUMINATION")]
    [SerializeField] Light2D[] _globalLights;
    [SerializeField] float _dayIntensity;
    [SerializeField] float _nightIntensity;

    [Header("BACKGROUND")]
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Color _dayColorModifier;
    [SerializeField] Color _nightColorModifier;

    Torch[] levelTorchs; 
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        levelTorchs = FindObjectsOfType<Torch>();
        TriggerDay();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TriggerDay();
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            TriggerNight();
        }
    }
#endif

    public void TriggerDay()
    {
        _spriteRenderer.color = _dayColorModifier;

        foreach (Light2D light in _globalLights)
            light.intensity = _dayIntensity;

        foreach (Torch torch in levelTorchs)
        {
            SetTorchesActive(false);
        }
    }

    public void TriggerNight()
    {
        _spriteRenderer.color = _nightColorModifier;

        foreach(Light2D light in _globalLights)
            light.intensity = _nightIntensity;


        foreach (Torch torch in levelTorchs)
        {
            SetTorchesActive(true);
        }
    }

    public void SetTorchesActive(bool active)
    {
        foreach (Torch torch in levelTorchs)
        {
            if(active)
                torch.FireOn();
            else
                torch.FireOff();
        }
    }
}
