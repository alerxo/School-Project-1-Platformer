using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerStats : MonoBehaviour
{ 
    private float health;

    [SerializeField]
    private float maxHealth;

    public float coins;

    private Vector2 respawnPos;

    private PlayerUI playerUI;
    private Animator animator;

    private CinemachineVirtualCamera vCam;

    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        animator = GetComponentInChildren<Animator>();
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();


        respawnPos = transform.position;

        health = maxHealth;
    }

    public void DmgTaken(float dmg)
    {
        health -= dmg;

        if (health > 0) animator.SetTrigger("Hurt");

        playerUI.SetHealth(maxHealth, health);

        GetComponentInChildren<SpriteRenderer>().color = Color.red;

        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 7;
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 7;

        Invoke(nameof(ResetColorAndNoise), 0.15f);

        if (health <= 0)
        {
            Dead();
        }
    }

    private void ResetColorAndNoise()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
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
