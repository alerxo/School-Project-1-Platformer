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
            StartCoroutine(PowerUp(collision.gameObject));
        }   
    }

    private IEnumerator PowerUp(GameObject player)
    {
        float orgSpeed = player.GetComponent<PlayerMovement>().jumpSpeed;
        float orgGrav = player.GetComponent<Rigidbody2D>().gravityScale;

        player.GetComponent<PlayerMovement>().jumpSpeed /= (powerUpAmount /= 2);

        player.GetComponent<Rigidbody2D>().gravityScale /= (powerUpAmount *= 2);



        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        player.GetComponent<PlayerMovement>().jumpSpeed = orgSpeed;
        player.GetComponent<Rigidbody2D>().gravityScale = orgGrav;

        Destroy(gameObject);
    }
}
