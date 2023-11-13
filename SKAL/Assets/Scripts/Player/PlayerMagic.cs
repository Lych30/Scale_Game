using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    public static PlayerMagic instance;

    Red _redPower;
    public Red RedPower { get { return _redPower; } }

    Blue _bluePower;
    public Blue BluePower { get { return _bluePower; } }

    Green _greenPower;
    public Green GreenPower { get { return _greenPower; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    public void AddRedPower()
    {
        if (_redPower != null)
        {
            _redPower.AddLevel();
            return;
        }
            

        _redPower = transform.AddComponent<Red>();
    }

    public void AddGreenPower()
    {
        if (_greenPower != null)
        {
            _greenPower.AddLevel();
            return;
        }

        _greenPower = transform.AddComponent<Green>();
    }

    public void AddBluePower()
    {
        if (_bluePower != null)
        {
            _bluePower.AddLevel();
            return;
        }

        _bluePower = transform.AddComponent<Blue>();
    }

}
