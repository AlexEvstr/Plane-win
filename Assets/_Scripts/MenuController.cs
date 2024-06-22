using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private Image _touchBtn;
    [SerializeField] private Image _accelerometerBtn;
    [SerializeField] private GameObject _levelsWindow;
    [SerializeField] private GameObject _statsWindow;
    [SerializeField] private GameObject _privacyWindow;
    [SerializeField] private GameObject _tutorialWindow;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Time.timeScale = 1;
    }

    private void Update()
    {
        CheckControl();
    }

    private void CheckControl()
    {
        int controlType = PlayerPrefs.GetInt("control", 0);
        if (controlType == 0)
        {
            _touchBtn.color = Color.green;
            _accelerometerBtn.color = Color.white;
        }
        else
        {
            _accelerometerBtn.color = Color.green;
            _touchBtn.color = Color.white;
        }
    }

    public void PlayButton()
    {
        _menuWindow.SetActive(false);
        _levelsWindow.SetActive(true);
    }

    public void CloseLevelsWindow()
    {
        _levelsWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }

    public void OpenSettingsButton()
    {
        _menuWindow.SetActive(false);
        _settingsWindow.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        _settingsWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }

    public void ChooseTouchControl()
    {
        PlayerPrefs.SetInt("control", 0);
    }

    public void ChooseAccelerometerControl()
    {
        PlayerPrefs.SetInt("control", 1);
    }

    public void OpenStatsWindow()
    {
        _menuWindow.SetActive(false);
        _statsWindow.SetActive(true);
    }

    public void CloseStatsWindow()
    {
        _statsWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }

    public void OpenPrivacyWindow()
    {
        _menuWindow.SetActive(false);
        _privacyWindow.SetActive(true);
    }

    public void ClosePrivacyWindow()
    {
        _privacyWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }

    public void OpenTutorialWindow()
    {
        _menuWindow.SetActive(false);
        _tutorialWindow.SetActive(true);
    }

    public void CloseTutorialWindow()
    {
        _tutorialWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }
}