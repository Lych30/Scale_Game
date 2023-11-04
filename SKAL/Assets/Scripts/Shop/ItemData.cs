using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item")]

public class ItemData : ScriptableObject
{
    public int cost;
    public Image image;
    public string description;
}