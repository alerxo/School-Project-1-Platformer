using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    private float duration = 5;

    [SerializeField]
    private float powerUpAmount = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(PowerUp(collision.GetComponent<PlayerMovement>()));
        }   
    }

    private IEnumerator PowerUp(PlayerMovement playerMovement)
    {
        float orgSpeed = playerMovement.moveSpeed;

        playerMovement.moveSpeed *= powerUpAmount;

        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        playerMovement.moveSpeed = orgSpeed;

        Destroy(gameObject);
    }
}
