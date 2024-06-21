using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneShop : MonoBehaviour
{
    public TMP_Text coinText;
    public Button[] airplaneButtons;
    public int[] airplaneCosts;

    private int coinCount;
    private int selectedAirplane;

    void Start()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        selectedAirplane = PlayerPrefs.GetInt("SelectedAirplane", -1);

        if (!IsAirplanePurchased(0))
        {
            PlayerPrefs.SetInt("AirplanePurchased_0", 1);
            PlayerPrefs.Save();
        }

        UpdateCoinText();
        UpdateAirplaneButtons();

        if (selectedAirplane == -1)
        {
            SelectAirplane(0);
        }
        else
        {
            HighlightSelectedAirplane();
        }
    }

    public void OnAirplaneButtonClick(int index)
    {
        if (index < 0 || index >= airplaneCosts.Length)
        {
            Debug.LogError("Invalid airplane index");
            return;
        }

        if (IsAirplanePurchased(index))
        {
            SelectAirplane(index);
        }
        else
        {
            BuyAirplane(index);
        }
    }

    private void BuyAirplane(int index)
    {
        int cost = airplaneCosts[index];

        if (coinCount >= cost)
        {
            coinCount -= cost;
            PlayerPrefs.SetInt("CoinCount", coinCount);
            PlayerPrefs.SetInt("AirplanePurchased_" + index, 1);
            PlayerPrefs.Save();

            UpdateCoinText();
            UpdateAirplaneButtons();
            SelectAirplane(index);
        }
        else
        {
            Debug.LogWarning("Not enough coins to buy this airplane.");
        }
    }

    private void SelectAirplane(int index)
    {
        selectedAirplane = index;
        PlayerPrefs.SetInt("SelectedAirplane", index);
        PlayerPrefs.Save();
        HighlightSelectedAirplane();
    }

    private bool IsAirplanePurchased(int index)
    {
        return PlayerPrefs.GetInt("AirplanePurchased_" + index, 0) == 1;
    }

    private void UpdateCoinText()
    {
        coinText.text = $"{coinCount}";
    }

    private void UpdateAirplaneButtons()
    {
        for (int i = 0; i < airplaneButtons.Length; i++)
        {
            TMP_Text buttonText = airplaneButtons[i].GetComponentInChildren<TMP_Text>();
            if (IsAirplanePurchased(i))
            {
                buttonText.text = "Select";
                airplaneButtons[i].interactable = true;
            }
            else
            {
                buttonText.text = "Buy (" + airplaneCosts[i] + ")";
                airplaneButtons[i].interactable = coinCount >= airplaneCosts[i];
            }
        }
    }

    private void HighlightSelectedAirplane()
    {
        for (int i = 0; i < airplaneButtons.Length; i++)
        {
            ColorBlock colors = airplaneButtons[i].colors;
            if (i == selectedAirplane)
            {
                colors.normalColor = Color.green;
                colors.selectedColor = Color.green;
                colors.highlightedColor = Color.green;
                colors.disabledColor = Color.green;
            }
            else
            {
                colors.normalColor = Color.white;
                colors.selectedColor = Color.white;
            }
            airplaneButtons[i].colors = colors;
        }
    }
}