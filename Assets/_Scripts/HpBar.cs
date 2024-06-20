using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image _currentHpImage;
    [SerializeField] private TMP_Text _percents;
    [SerializeField] private GameObject _loseWindow; 
    [SerializeField] private GameObject _plane;
    [SerializeField] private CloneManager _cloneManager;

    private float maxHp;
    public static float CurrentHp;

    private void Start()
    {
        maxHp = 1.0f;
        CurrentHp = 1.0f;
        StartCoroutine(HpDecrease());
    }

    private IEnumerator HpDecrease()
    {
        while (CurrentHp > 0)
        {
            CurrentHp -= 0.001f;
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(OpenGameLose());
    }

    private void Update()
    {
        if (CurrentHp >= 1)
        {
            CurrentHp = 1;
            _cloneManager.CreateClone();
        }
        else if (CurrentHp < 0)
        {
            CurrentHp = 0;
        }
        _currentHpImage.fillAmount = CurrentHp / maxHp;
        _percents.text = (100 * CurrentHp).ToString("f0") + "%";
    }

    private IEnumerator OpenGameLose()
    {
        _plane.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1.0f);
        _loseWindow.SetActive(true);
        Time.timeScale = 0;
    }
}
