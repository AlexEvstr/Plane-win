using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int levelIndex;

    private void Awake()
    {
        levelIndex = PlayerPrefs.GetInt("LevelIndex", 1);
    }
}
