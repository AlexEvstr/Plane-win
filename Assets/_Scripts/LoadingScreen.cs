using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadNextScene());
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("menuScene");

    }
}