﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static float spotCount = 5.00f;

    bool gameHasEnded = false;

    //public float restartDelay = 0.1f;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            GameOverMenu.gameIsOver = true;
        }

    }
}

