using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinQuest : MonoBehaviour
{
    private PlayerStats playerStats;

    private GameObject doorObj;

    [SerializeField]
    private float maxCoins;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        playerStats = player.GetComponent<PlayerStats>();

        doorObj = GameObject.FindGameObjectWithTag("Door");
    }

    private void Update()
    {
        if(playerStats.coins == maxCoins)
        {
            doorObj.SendMessage("Open");
            Destroy(gameObject);
        }
    }
}
