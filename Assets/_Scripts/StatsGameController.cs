using UnityEngine;

public class StatsGameController : MonoBehaviour
{
    public static int EnemiesCount;
    public static int BonusesCount;
    public static int LosesCount;

    private void Start()
    {
        EnemiesCount = PlayerPrefs.GetInt("enemiesCount", 0);
        BonusesCount = PlayerPrefs.GetInt("bonusesCount", 0);
        LosesCount = PlayerPrefs.GetInt("losesCount", 0);
    }
}