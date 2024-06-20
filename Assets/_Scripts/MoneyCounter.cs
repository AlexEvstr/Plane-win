using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _coinBalanceText;
    public static int CoinsLevel;
    public static int CoinBalance;

    private void Start()
    {
        CoinsLevel = 0;
        CoinBalance = PlayerPrefs.GetInt("coinBalance", 0);
    }

    private void Update()
    {
        _moneyText.text = $"{CoinsLevel}/5";
        _coinBalanceText.text = CoinBalance.ToString();
    }
}