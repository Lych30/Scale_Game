using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryBarrel : Barrel
{
    AdversaryStats _adversaryStats;
    public override void Init(int litres, AdversaryStats stats)
    {
        _LitresToDring  = litres;
        _adversaryStats = stats;
    }

    public override void Sip()
    {
        _LitresToDring -= _adversaryStats.capacity;
        if (_LitresToDring <= 0)
            GameManager.instance.Loose(_adversaryStats.name);
        //UPDATE VISUALS
    }
}
