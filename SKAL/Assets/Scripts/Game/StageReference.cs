using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageReference : MonoBehaviour
{
    public static StageReference instance;

    [SerializeField] private PlayerBarrel PlayerBarrel;
    public PlayerBarrel playerBarrel { get { return PlayerBarrel; } }

    [SerializeField] private AdversaryBarrel AdversaryBarrel;
    public AdversaryBarrel adversaryBarrel { get { return AdversaryBarrel; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
