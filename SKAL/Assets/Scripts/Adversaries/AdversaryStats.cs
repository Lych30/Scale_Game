using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AdversaryStats", menuName = "Data/Adversary Stats")]
public class AdversaryStats : ScriptableObject
{
    public int tolerance; //WHEN THE PLAYER WILL START TO FEEL DIZZY
    public int capacity; //HOW MUCH THE PLAYER CAN DRINK EACH SIP
    public Difficulty difficulty;
    
}
public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    Ragnarok
}