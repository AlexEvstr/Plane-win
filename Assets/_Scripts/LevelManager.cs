using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelIndexText;
    public static int levelIndex;

    private void Awake()
    {
        levelIndex = PlayerPrefs.GetInt("LevelIndex", 1);
        _levelIndexText.text = $"{levelIndex} level";
    }
}