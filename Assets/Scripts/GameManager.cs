using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayerController playerController;
    [SerializeField] public ScoreUI scoreUI;
    [SerializeField] public EnergyUI energyUI;
    [SerializeField] public PlayerFade playerFade;
    [SerializeField] public GameOverUI gameOverUI;
    [SerializeField] public SpeedUI SpeedUI;

    private void Awake()
    {
        Coins.TakeCoin += TakeCoin;
        Obstacle.ObstacleTrigger += ObstacleTrigger;
        EnergyPU.EnergyPickedUp += EnergyPickedUp;
        SpeedPU.SpeedPickedUp += SpeedPickedUp;
        playerFade.energyChanged += EnergyChanged;
        gameOverUI.restartGame += RestartGame;
        gameOverUI.mainMenu += MainMenu;
    }

    private void OnDestroy()
    {
        Coins.TakeCoin -= TakeCoin;
        Obstacle.ObstacleTrigger -= ObstacleTrigger;
        EnergyPU.EnergyPickedUp -= EnergyPickedUp;
        SpeedPU.SpeedPickedUp -= SpeedPickedUp;
        playerFade.energyChanged -= EnergyChanged;
        gameOverUI.restartGame -= RestartGame;
        gameOverUI.mainMenu -= MainMenu;
    }

    public void TakeCoin(int score)
    {
        playerController.addScore(score);
        scoreUI.SetScore(playerController.score);
    }

    public void ObstacleTrigger(bool canFaded)
    {
        if(!canFaded || (canFaded && !playerController.isFaded))
        {
            GameOver();
        }
    }

    public void EnergyPickedUp(float energy)
    {
        playerController.addEnergy(energy);
        energyUI.SetEnergy(playerController.energy);
    }

    public void SpeedPickedUp(float speed, float time)
    {
        if(speed > playerController.baseSpeed)
        {
            SpeedUI.SetText("SpeedUP", Color.yellow, time);
        } else
        {
            SpeedUI.SetText("SpeedSlow", Color.red, time);
        }
        StopAllCoroutines();
        playerController.setDefaultSpeed();
        StartCoroutine(SpeedChange(speed, time));
    }

    public void EnergyChanged(float energy)
    {
        energyUI.SetEnergy(energy);
        playerController.changeEnergy(energy);
    }

    private void GameOver()
    {
        SpeedUI.HideText();
        StopCoroutine("SpeedChange");
        Time.timeScale = 0;
        gameOverUI.Activate();
        playerController.DisableCharacter();
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator SpeedChange(float speed, float time)
    {
        playerController.changeSpeed(speed);
        yield return new WaitForSeconds(time);
        playerController.setDefaultSpeed();
        SpeedUI.HideText();
        yield return null;
    }
}
