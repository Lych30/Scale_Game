using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item")]

public class ItemData : ScriptableObject
{
    public string itemName;
    public int itemCost;
    public Image itemImage;
    public string itemDescription;
}