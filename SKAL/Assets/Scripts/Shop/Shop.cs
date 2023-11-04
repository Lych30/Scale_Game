using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    [SerializeField] List<ItemData> _datas;
    public List<ItemData> datas { get { return _datas; } }

    [SerializeField] Item _Item;
    [SerializeField] List<VerticalLayoutGroup> _vertLGroups;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }
    public void OpenShop()
    {
        int layoutIndex = 0;
        VerticalLayoutGroup currentLayoutGroup = _vertLGroups[layoutIndex];

        for(int i = 0; i < _datas.Count; i++)
        {
            if (currentLayoutGroup.transform.childCount >= 3)
            {
                layoutIndex++;

                if (layoutIndex >= 4)
                    break;

                currentLayoutGroup = _vertLGroups[layoutIndex];
            }

            Item item = Instantiate(_Item, currentLayoutGroup.transform);
            item.Init(_datas[i]);
        }
    }

    public void BuyItem(Item item)
    {
        Debug.Log("You have bought : " + item.itemName +" for "+ item.cost + " currencies");
    }
}
