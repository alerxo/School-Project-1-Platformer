using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObserver : MonoBehaviour
{
    public static void LevelsCompletedToMemory(int level)
    {
        PlayerPrefs.SetInt("CompletedLevels", level);
    }
}
