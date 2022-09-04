using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCText : MonoBehaviour
{
    private TextMeshProUGUI questText;

    [SerializeField]
    private LayerMask targetMask;

    [SerializeField]
    private string questInfo1;

    [SerializeField]
    private string questInfo2;

    private void Start()
    {
        questText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) questText.text = questInfo1;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) questText.text = questInfo2;
    }
}   
