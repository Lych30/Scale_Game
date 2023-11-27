using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    [SerializeField] List<ItemData> _datas;
    public List<ItemData> datas { get { return _datas; } }

    [SerializeField] Item _Item;
    [SerializeField] List<VerticalLayoutGroup> _vertLGroups;
    private List<GameObject> _Activeitems = new List<GameObject>();

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        InitShop();
    }
    public void InitShop()
    {
        int layoutIndex = 0;
        VerticalLayoutGroup currentLayoutGroup = _vertLGroups[layoutIndex];

        for (int i = 0; i < _datas.Count; i++)
        {
            if (currentLayoutGroup.transform.childCount >= 3)
            {
                layoutIndex++;

                if (layoutIndex >= 3)
                    break;

                currentLayoutGroup = _vertLGroups[layoutIndex];
            }

            Item item = Instantiate(_Item, currentLayoutGroup.transform);
            _Activeitems.Add(item.gameObject);
            item.Init(_datas[i]);
            item.gameObject.SetActive(false);
        }

    }
    public void LoadShop()
    {
        foreach (GameObject item in _Activeitems)
        {
            item.SetActive(true);
        }

        if (_vertLGroups[0].transform.childCount > 0)
            ESReference.instance.eventSystem.SetSelectedGameObject(_vertLGroups[0].transform.GetChild(0).GetChild(0).gameObject);

        foreach (GameObject item in _Activeitems)
        {
            if(item.GetComponent<Item>().canBeBought)
            {
                ESReference.instance.eventSystem.SetSelectedGameObject(item.transform.GetChild(0).gameObject);
                break;
            }
        }

        
    }
    /*
    public void LoadShop()
    {
        int layoutIndex = 0;
        VerticalLayoutGroup currentLayoutGroup = _vertLGroups[layoutIndex];

        for(int i = 0; i < _datas.Count; i++)
        {
            if (currentLayoutGroup.transform.childCount >= 3)
            {
                layoutIndex++;

                if (layoutIndex >= 3)
                    break;

                currentLayoutGroup = _vertLGroups[layoutIndex];
            }

            Item item = Instantiate(_Item, currentLayoutGroup.transform);
            _Activeitems.Add(item.gameObject);
            item.Init(_datas[i]);
        }

        if(_vertLGroups[0].transform.childCount > 0)
            ESReference.instance.eventSystem.SetSelectedGameObject(_vertLGroups[0].transform.GetChild(0).GetChild(0).gameObject);
    }
    */

    public IEnumerator UnLoadShop()
    {
        yield return new WaitForSeconds(1);

        foreach (GameObject item in _Activeitems)
        {
            item.SetActive(false);
        }
    }
    

    public void BuyItem(Item item)
    {
        item.ApplyItemStats(item.Data);
        Debug.Log("You have bought : " + item.itemName +" for "+ item.cost + " currencies");
    }
}
