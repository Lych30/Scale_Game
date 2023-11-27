using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AdversaryStats", menuName = "Data/Adversary Stats")]
public class AdversaryStats : ScriptableObject
{
    public string name;
    public string title;
    public int tolerance; //WHEN THE PLAYER WILL START TO FEEL DIZZY
    public float capacity; //HOW MUCH THE PLAYER CAN DRINK EACH SIP
    public float outsidePrecision;
    public float insidePrecision;
    public Difficulty difficulty;
    public GameObject gfx;
    public int currencyReward;
    public int magicPointsReward;
    
}
public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    Einherjar
}
