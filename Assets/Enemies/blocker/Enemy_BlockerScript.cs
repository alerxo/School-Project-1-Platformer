using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BlockerScript : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SendMessage("DmgTaken", damage);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
