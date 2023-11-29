using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public enum TimeOfDay
{
    Day,
    Night
}
public class DayCycleManager : MonoBehaviour
{
    public static DayCycleManager instance;

    [Header("GLOBAL ILLUMINATION")]
    [SerializeField] Light2D _globalLights;
    [SerializeField] float _dayIntensity;
    [SerializeField] float _nightIntensity;

    [Header("BACKGROUND")]
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Color _dayColorModifier;
    [SerializeField] Color _nightColorModifier;

    Torch[] levelTorchs;
    [SerializeField] AudioSource _fireSource;

    [SerializeField] TimeOfDay _startTime;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        levelTorchs = FindObjectsOfType<Torch>();

        switch (_startTime)
        {
            case TimeOfDay.Day: TriggerDay();
                break;
            case TimeOfDay.Night: TriggerNight();
                break;
        }
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

        _globalLights.intensity = _dayIntensity;

        foreach (Torch torch in levelTorchs)
        {
            SetTorchesActive(false);
        }

        _fireSource.Stop();
    }

    public void TriggerNight()
    {
        _spriteRenderer.color = _nightColorModifier;
        _globalLights.intensity = _nightIntensity;



        foreach (Torch torch in levelTorchs)
        {
            SetTorchesActive(true);
        }

        _fireSource.Play();
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
