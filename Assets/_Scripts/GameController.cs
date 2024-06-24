using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private AccelerometerControl _accelerometerControl;
    [SerializeField] private TouchControl _touchControl;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private SpriteRenderer _planeSpriteRenderer;
    [SerializeField] private Sprite[] _planes;
    private void Start()
    {
        Time.timeScale = 1;

        int index = PlayerPrefs.GetInt("SelectedAirplane", 0);
        _planeSpriteRenderer.sprite = _planes[index];

        int controlType = PlayerPrefs.GetInt("control", 0);
        if (controlType == 1)
        {
            _accelerometerControl.enabled = true;    
        }
        else
        {
            _touchControl.enabled = true;
        }
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void PauseGameButton()
    {
        _pauseButton.SetActive(false);
        _pauseWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        _pauseWindow.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("menuScene");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("gameScene");
    }
}