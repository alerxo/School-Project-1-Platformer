using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    private TextMeshProUGUI questText;

    [SerializeField]
    private string text;

    void Start()
    {
        questText = GetComponentInChildren<TextMeshProUGUI>();
        questText.text = text;
    }
}
