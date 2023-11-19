using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName ="Data/Player Stats")]
public class PlayerStats : ScriptableObject
{
    public string name;
    public float tolerance; //WHEN THE PLAYER WILL START TO FEEL DIZZY
    public float BaseTolerance; //WHEN THE PLAYER WILL START TO FEEL DIZZY
    public float capacity; //HOW MUCH THE PLAYER CAN DRINK EACH SIP
    public float BaseCapacity; //HOW MUCH THE PLAYER CAN DRINK EACH SIP
    //ONE SIP ON AVERAGE IS 4CL SO WE WILL MULTIPLY THIS VALUE WITH THE CAPACITY
    public int magicPoints;
    public int RedMagic;
    public int BlueMagic;
    public int GreenMagic;
    public int currency;
    
}
