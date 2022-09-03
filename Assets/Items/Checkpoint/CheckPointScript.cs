using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    [SerializeField]
    private Sprite disabledSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<PlayerStats>().ChangeCheckPoint(gameObject);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().sprite = disabledSprite;
        }
    }
}
