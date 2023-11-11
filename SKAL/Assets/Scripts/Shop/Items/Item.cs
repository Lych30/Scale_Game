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
    [SerializeField] GameObject _disabledButton;
    [SerializeField] TextMeshProUGUI _nameText;
    public string itemName { get { return _nameText.text; } }

    int _cost;
    public int cost { get { return _cost; } }

    [SerializeField] TextMeshProUGUI _costText;
    [SerializeField] Image _image;
    [SerializeField] TextMeshProUGUI _description;
    bool _canBeBought = true;
    public void Init(ItemData data)
    {
        _data = data;

        _nameText.text = data.itemName;

        _cost = data.itemCost;
        _costText.text = _cost.ToString();

        _image = data.itemImage;

        _description.text = data.itemDescription;
        SetVisual();
    }

    public void BuyItemClick()
    {
        if (!_canBeBought)
            return;

        SetVisual();
        _disabledButton.SetActive(true);
        Shop.instance.BuyItem(this);
        Shop.instance.datas.Remove(_data);

    }

    public void SetVisual()
    {
        switch (_canBeBought)
        {
            case true:
                _disabledButton.SetActive(false);
                break;
            case false:
                _nameText.color = Color.red;
                _costText.color = Color.red;
                _disabledButton.SetActive(true);
                break;
        }
    }

    public void ApplyItemStats(ItemData data)
    {
        PlayerManager.instance.Stats.capacity += data.capacityBuff;
        PlayerManager.instance.Stats.tolerance += data.toleranceBuff;
        PlayerManager.instance.UpdateStats();
    }
}
