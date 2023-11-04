using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] protected float _LitresToDring;

    public virtual void Init(int litres, PlayerStats stats)
    {
    }

    public virtual void Init(int litres, AdversaryStats stats)
    {
    }

    public virtual void Sip()
    {
    }
}
