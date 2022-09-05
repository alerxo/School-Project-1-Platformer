using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{
    private bool open = false;

    [SerializeField]
    private Sprite openDoor1;
    [SerializeField]
    private Sprite openDoor2;

    [SerializeField]
    private int sceneNumber;

    [SerializeField]
    private int nextScene;

    private void Open()
    {
        open = true;

        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = openDoor1;
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = openDoor2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && open)
        {
            GameObserver.LevelsCompletedToMemory(sceneNumber);
            SceneManager.LoadScene(nextScene);
        }
    }
}