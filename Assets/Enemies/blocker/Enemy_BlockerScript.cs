using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BlockerScript : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.parent.SendMessage("DmgTaken", damage);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
