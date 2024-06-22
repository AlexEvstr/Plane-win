using System.Collections;
using UnityEngine;

public class PlaneTriggerDetector : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private AudioAndVibroGame audioAndVibroGame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            audioAndVibroGame.PlayEnemyAudioClip();
            HpBar.CurrentHp -= 0.2f;
            Destroy(collision.gameObject);
            StatsGameController.EnemiesCount++;
            PlayerPrefs.SetInt("enemiesCount", StatsGameController.EnemiesCount);
        }
        else if (collision.gameObject.tag == "UFO")
        {
            audioAndVibroGame.PlayEnemyAudioClip();
            HpBar.CurrentHp -= 0.35f;
            Destroy(collision.gameObject);
            StatsGameController.EnemiesCount++;
            PlayerPrefs.SetInt("enemiesCount", StatsGameController.EnemiesCount);
        }
        else if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            audioAndVibroGame.PlayCoinAudio();
            MoneyCounter.CoinsLevel++;
            MoneyCounter.CoinBalance++;
            PlayerPrefs.SetInt("coinBalance", MoneyCounter.CoinBalance);
            if (MoneyCounter.CoinsLevel == 5)
            {
                StartCoroutine(OpenGameWin());
            }
        }
        else if (collision.gameObject.tag == "scoreObject")
        {
            audioAndVibroGame.PlayBonusAudio();
            HpBar.CurrentHp += float.Parse(collision.gameObject.name.Replace("(Clone)", "").Trim())/100;
            Destroy(collision.gameObject);
            StatsGameController.BonusesCount++;
            PlayerPrefs.SetInt("bonusesCount", StatsGameController.BonusesCount);
        }
    }

    private IEnumerator OpenGameWin()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1.0f);
        audioAndVibroGame.PlayWinSound();
        _winWindow.SetActive(true);
        LevelManager.levelIndex++;
        PlayerPrefs.SetInt("LevelIndex", LevelManager.levelIndex);
        int highestUnlockedLevel = PlayerPrefs.GetInt("HighestUnlockedLevel", 1);
        if (highestUnlockedLevel < LevelManager.levelIndex)
        {
            highestUnlockedLevel = LevelManager.levelIndex;
            PlayerPrefs.SetInt("HighestUnlockedLevel", highestUnlockedLevel);
        }
        Time.timeScale = 0;
    }
}