using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AdversaryStats", menuName = "Data/Adversary Stats")]
public class AdversaryStats : ScriptableObject
{
    public string name;
    public int tolerance; //WHEN THE PLAYER WILL START TO FEEL DIZZY
    public float capacity; //HOW MUCH THE PLAYER CAN DRINK EACH SIP
    public float precision; //PRECISION ON THE QTE
    public Difficulty difficulty;
    
}
public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    Einherjar
}
