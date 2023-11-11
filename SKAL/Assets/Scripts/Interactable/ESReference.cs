using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ESReference : MonoBehaviour
{
    public static ESReference instance;
    [SerializeField] EventSystem _eventSystem;
    public EventSystem eventSystem { get { return _eventSystem; } }
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;

    }
}
