using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item")]

public class ItemData : ScriptableObject
{
    public string itemName;
    public int itemCost;
    public Sprite itemImage;
    public string itemDescription;
    public float toleranceBuff;
    public float capacityBuff;
}