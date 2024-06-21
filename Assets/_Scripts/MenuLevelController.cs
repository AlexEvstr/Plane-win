using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevelController : MonoBehaviour
{
    private Button levelButton;
    private Image buttonImage;
    private int levelNumber;

    private void Start()
    {
        InitializeLevel();
    }

    private void InitializeLevel()
    {
        levelButton = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        if (levelButton == null || buttonImage == null || !int.TryParse(gameObject.name, out levelNumber))
        {
            return;
        }

        int highestUnlockedLevel = PlayerPrefs.GetInt("HighestUnlockedLevel", 1);
        if (highestUnlockedLevel < levelNumber)
        {
            levelButton.enabled = false;
            buttonImage.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            levelButton.enabled = true;
            buttonImage.color = new Color(1f, 1f, 1f);
            if (transform.childCount > 1)
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void OnLevelSelected()
    {
        if (int.TryParse(gameObject.name, out levelNumber))
        {
            PlayerPrefs.SetInt("LevelIndex", levelNumber);
            SceneManager.LoadScene("gameScene");
        }
    }
}