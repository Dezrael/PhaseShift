using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] BestScoreUI bestScore;
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        bestScore.SetScore(scoreManager.bestScore);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
