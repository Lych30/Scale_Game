using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryManager : MonoBehaviour
{
    public AdversaryStats stats;

    int _tolerance;
    int _capacity;

    private void Start()
    {
        _tolerance = stats.tolerance;
        _capacity = stats.capacity;
    }
}
