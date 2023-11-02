using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public static PlayerCoins instance;
    [SerializeField] int _currency;
    [SerializeField] TextMeshProUGUI _currencyText;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        UpdateCurrencyText();
    }
    public void AddCurrency(int amount)
    {
        _currency += amount;
        UpdateCurrencyText();
    }
    public bool CheckCurrency(int amount)
    {
        return (amount <= _currency);
    }
    public void RemoveCurrency(int amount)
    {
        _currency -= amount;
        UpdateCurrencyText();
    }
    private void UpdateCurrencyText()
    {
        if (_currencyText == null)
            return;

        _currencyText.text = _currency.ToString();
    }
}
