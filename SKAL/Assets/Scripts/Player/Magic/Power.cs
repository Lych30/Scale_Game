using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPower
{
    public void ApplyPower();
}

[Serializable]
public enum PowerColor
{
    Red,
    Green,
    Blue
}

public class Power : MonoBehaviour, IPower
{
    [SerializeField] protected int _level = 1;
    protected int _maxLevel = 10;
    bool _isMaxLevel = false;
    public bool IsMaxLevel { get { return _isMaxLevel; } }
    public virtual void ApplyPower() {}

    public void AddLevel()
    {
        if (_isMaxLevel)
            return;

        _level++;
        if( _level >= _maxLevel)
        {
            _isMaxLevel = true;
            _level = _maxLevel;
        }
            
    }
}
