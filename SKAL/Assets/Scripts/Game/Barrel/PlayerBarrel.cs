using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrel : Barrel
{
    PlayerStats _playerStats;
    public override void Init(int litres, PlayerStats stats)
    {
        _LitresToDring = litres;
        _playerStats = stats;
    }

    public override void Sip()
    {
        _LitresToDring -= _playerStats.capacity;
        Debug.Log(_LitresToDring);

        if (_LitresToDring <= 0)
            GameManager.instance.Win(_playerStats.name);
        //UPDATE VISUALS
    }
}
