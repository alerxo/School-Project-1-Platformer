using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{ 
    private float health;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float coins;

    private Vector2 respawnPos;

    private PlayerUI playerUI;
    private Animator animator;

    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        animator = GetComponentInChildren<Animator>();

        respawnPos = transform.position;

        health = maxHealth;
    }

    public void DmgTaken(float dmg)
    {
        health -= dmg;

        if (health > 0) animator.SetTrigger("Hurt");

        playerUI.SetHealth(maxHealth, health);

        if (health <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        transform.position = respawnPos;
        health = maxHealth;
        playerUI.SetHealth(maxHealth, health);
    }

    public void AddCoin(float amount)
    {
        coins += amount;
        playerUI.SetCoinText(coins);
    }

    public void ChangeCheckPoint(GameObject checkPoint)
    {
        respawnPos = checkPoint.transform.position;
    }
}
