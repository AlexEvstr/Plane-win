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
}