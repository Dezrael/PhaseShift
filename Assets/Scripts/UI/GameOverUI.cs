using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public event Action restartGame;
    public event Action mainMenu;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        restartGame();
    }

    public void MainMenu()
    {
        mainMenu();
    }
}
