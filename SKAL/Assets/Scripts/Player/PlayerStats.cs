using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName ="Data/Player Stats")]
public class PlayerStats : ScriptableObject
{
    public string name;
    public int tolerance; //WHEN THE PLAYER WILL START TO FEEL DIZZY
    public int BaseTolerance; //WHEN THE PLAYER WILL START TO FEEL DIZZY
    public float capacity; //HOW MUCH THE PLAYER CAN DRINK EACH SIP
    public float BaseCapacity; //HOW MUCH THE PLAYER CAN DRINK EACH SIP
    //ONE SIP ON AVERAGE IS 4CL SO WE WILL MULTIPLY THIS VALUE WITH THE CAPACITY
}
