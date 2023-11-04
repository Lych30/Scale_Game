using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IItemEffect
{
    [SerializeField] ItemData _data;
    public ItemData Data { get { return _data; } }
    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _nameText;
    public string itemName { get { return _nameText.text; } }

    int _cost;
    public int cost { get { return _cost; } }

    [SerializeField] TextMeshProUGUI _costText;
    [SerializeField] Image _image;
    [SerializeField] TextMeshProUGUI _description;

    public void Init(ItemData data)
    {
        _data = data;

        _nameText.text = data.itemName;

        _cost = data.itemCost;
        _costText.text = _cost.ToString();

        _image = data.itemImage;

        _description.text = data.itemDescription;
    }

    public void BuyItemClick()
    {
        Shop.instance.BuyItem(this);
        Shop.instance.datas.Remove(_data);
    }

    public void ApplyItemStats(ItemData data)
    {
        PlayerManager.instance.Stats.capacity += data.capacityBuff;
        PlayerManager.instance.Stats.tolerance += data.toleranceBuff;
        PlayerManager.instance.UpdateStats();
    }
}
