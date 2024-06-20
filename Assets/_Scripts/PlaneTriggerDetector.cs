using System.Collections;
using UnityEngine;

public class PlaneTriggerDetector : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "UFO")
        {
            Debug.Log(collision.gameObject.name);
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
            Debug.Log(collision.gameObject.name);
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
        Time.timeScale = 0;
    }
}