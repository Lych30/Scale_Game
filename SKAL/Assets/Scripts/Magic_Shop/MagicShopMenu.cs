using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MagicShopMenu : MonoBehaviour
{
    public static MagicShopMenu instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;

    }
}
