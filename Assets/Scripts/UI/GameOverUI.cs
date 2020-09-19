using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public event Action restartGame;
    public event Action mainMenu;
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        panel.SetActive(false);
    }

    public void Activate()
    {
        panel.SetActive(true);
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
