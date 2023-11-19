using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    public static PlayerMagic instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    public void AddRedPower()
    {

            PlayerManager.instance.stats.RedMagic++;
        
    }

    public void AddGreenPower()
    {
            PlayerManager.instance.stats.GreenMagic++;
    }

    public void AddBluePower()
    {

            PlayerManager.instance.stats.BlueMagic++;

    }

}
