using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private AccelerometerControl _accelerometerControl;
    [SerializeField] private TouchControl _touchControl;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _pauseWindow;
    private void Start()
    {
        Time.timeScale = 1;
        int controlType = PlayerPrefs.GetInt("control", 0);
        if (controlType == 1)
        {
            _accelerometerControl.enabled = true;    
        }
        else
        {
            _touchControl.enabled = true;
        }
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
}
