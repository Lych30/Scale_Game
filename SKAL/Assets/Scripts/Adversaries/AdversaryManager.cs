using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryManager : MonoBehaviour
{

    [SerializeField] int _tolerance;
    [SerializeField] int _capacity;

    public void InitAdversary(AdversaryStats stats)
    {
        _tolerance = stats.tolerance;
        _capacity = stats.capacity;
    }
}
