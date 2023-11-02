using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName ="Data/Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int tolerance; //WHEN THE PLAYER WILL START TO FEEL DIZZY
    public int capacity; //HOW MUCH THE PLAYER CAN DRINK EACH SIP
}
