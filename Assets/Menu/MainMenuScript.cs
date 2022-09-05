using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    private int nextScene = 1;

    [SerializeField]
    private TextMeshProUGUI levelCompletedText;

    public void Start()
    {
        levelCompletedText.text = "Levels Completed: " + PlayerPrefs.GetInt("CompletedLevels").ToString();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartButton()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ResetLevelButton()
    {
        GameObserver.LevelsCompletedToMemory(0);

        levelCompletedText.text = "Levels Completed: " + PlayerPrefs.GetInt("CompletedLevels").ToString();



        Debug.Log(PlayerPrefs.GetInt("CompletedLevels"));
    }

    public void QuitButton()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
