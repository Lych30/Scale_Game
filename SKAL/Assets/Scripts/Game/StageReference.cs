using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageReference : MonoBehaviour
{
    public static StageReference instance;

    [SerializeField] private Transform PlayerBarrel;
    public Transform playerBarrel { get { return PlayerBarrel; } }

    [SerializeField] private Transform AdversaryBarrel;
    public Transform adversaryBarrel { get { return AdversaryBarrel; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
