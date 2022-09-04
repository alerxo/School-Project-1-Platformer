using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private ParticleSystem particles;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip coinPickUpSound;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SendMessage("AddCoin", 1);

            StartCoroutine(PickUp());
        }
    }

    private IEnumerator PickUp()
    {
        particles.Play();
        audioSource.PlayOneShot(coinPickUpSound);

        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
