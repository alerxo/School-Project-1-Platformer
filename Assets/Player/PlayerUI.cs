using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private TextMeshProUGUI coinText;

    public void SetHealth(float max, float current)
    {
        healthSlider.maxValue = max;
        healthSlider.value = current;
    }

    public void SetCoinText(float current)
    {
        coinText.text = current.ToString();
    }
}
