using System.Collections;
using UnityEngine;

public class PlaneTriggerDetector : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HpBar.CurrentHp -= 0.2f;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "UFO")
        {
            HpBar.CurrentHp -= 0.35f;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
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
            HpBar.CurrentHp += float.Parse(collision.gameObject.name.Replace("(Clone)", "").Trim())/100;
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator OpenGameWin()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1.0f);
        _winWindow.SetActive(true);
        LevelManager.levelIndex++;
        PlayerPrefs.SetInt("LevelIndex", LevelManager.levelIndex);
        int highestUnlockedLevel = PlayerPrefs.GetInt("HighestUnlockedLevel", 1);
        if (highestUnlockedLevel < LevelManager.levelIndex)
        {
            highestUnlockedLevel = LevelManager.levelIndex;
            PlayerPrefs.SetInt("highestUnlockedLevel < LevelManager.levelIndex", highestUnlockedLevel);
        }
        Time.timeScale = 0;
    }
}