using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]   
    private float health;

    [SerializeField]
    private float coins;

    private PlayerUI playerUI;
    private Animator animator;

    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        animator = GetComponentInChildren<Animator>();
    }

    public void DmgTaken(float dmg)
    {
        health -= dmg;

        if (health > 0) animator.SetTrigger("Hurt");

        playerUI.SetHealth(10, health);

        if (health <= 0)
        {
            animator.SetTrigger("Dead");
            Destroy(gameObject);
        }
    }

    public void AddCoin(float amount)
    {
        coins += amount;
        playerUI.SetCoinText(coins);
    }
}
