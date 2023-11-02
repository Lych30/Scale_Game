using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryManager : MonoBehaviour
{

    [SerializeField] int _tolerance;
    [SerializeField] int _capacity;
    Difficulty _difficulty;

    [Header("Adversary Precision")]
    float PrecisionAmount_Tier1;
    float PrecisionAmount_Tier2;
    float PrecisionAmount_Tier3;
    float PrecisionAmount_Tier4;

    float PrecisionAmount = 0;

    void Update()
    {
        if (!GameManager.instance.gameActive)
            return;
    }

    #region Init
    public void InitAdversary(AdversaryStats stats)
    {
        _tolerance = stats.tolerance;
        _capacity = stats.capacity;
        _difficulty = stats.difficulty;
        InitPrecision(_difficulty);
    }

    private void InitPrecision(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                PrecisionAmount = PrecisionAmount_Tier1;
                break;

            case Difficulty.Medium:
                PrecisionAmount = PrecisionAmount_Tier2;
                break;

            case Difficulty.Hard:
                PrecisionAmount = PrecisionAmount_Tier3;
                break;

            case Difficulty.Ragnarok:
                PrecisionAmount = PrecisionAmount_Tier4;
                break;

            default:
                PrecisionAmount = PrecisionAmount_Tier1;
                break;
        }
    }
    #endregion
}
