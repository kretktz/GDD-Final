﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool gameIsOver = false;

    public GameObject gameOverMenuUI;

    private void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsOver)
        {
            gameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gameOverMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetCounter();
        gameIsOver = false;
    }

    void ResetCounter()
    {
        Manager.spotCount = 5.00f;
    }

    public void LoadMenu()
    {
        Restart();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
