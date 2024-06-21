using UnityEngine;
using TMPro;

public class MenuStatsWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text enemiesText;
    [SerializeField] private TMP_Text bonusesText;
    [SerializeField] private TMP_Text losesText;

    private void Start()
    {
        enemiesText.text = PlayerPrefs.GetInt("enemiesCount", 0).ToString();
        bonusesText.text = PlayerPrefs.GetInt("bonusesCount", 0).ToString();
        losesText.text = PlayerPrefs.GetInt("losesCount", 0).ToString();
    }
}