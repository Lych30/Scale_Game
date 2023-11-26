using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public static PlayerCoins instance;
    [SerializeField] TextMeshProUGUI[] _currencyTexts;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        UpdateCurrencyTexts();
    }
    public void AddCurrency(int amount)
    {
        PlayerManager.instance.stats.currency += amount;
        UpdateCurrencyTexts();
    }
    public bool CheckCurrency(int amount)
    {
        return (amount <= PlayerManager.instance.stats.currency);
    }
    public void RemoveCurrency(int amount)
    {
        PlayerManager.instance.stats.currency -= amount;
        UpdateCurrencyTexts();
    }
    private void UpdateCurrencyTexts()
    {
        if (_currencyTexts == null)
            return;

        foreach (TextMeshProUGUI currencytext in _currencyTexts)
            currencytext.text = "currency : " + PlayerManager.instance.stats.currency.ToString();
    }
}
