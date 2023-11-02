using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryManager : MonoBehaviour
{

    [SerializeField] int _tolerance;
    [SerializeField] int _capacity;
    Difficulty _difficulty;

    float _precision = 0;

    void Update()
    {
        if (!GameManager.instance.gameActive)
            return;
    }

    public void InitAdversary(AdversaryStats stats)
    {
        _tolerance = stats.tolerance;
        _capacity = stats.capacity;
        _difficulty = stats.difficulty;
        _precision = stats.precision;
    }
}
