using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayerController playerController;
    [SerializeField] public ScoreUI scoreUI;
    [SerializeField] public BestScoreUI bestScoreUI;
    [SerializeField] public EnergyUI energyUI;
    [SerializeField] public PlayerFade playerFade;
    [SerializeField] public GameOverUI gameOverUI;
    [SerializeField] public SpeedUI SpeedUI;
    [SerializeField] public ScoreManager scoreManager;

    private void Start()
    {
        bestScoreUI.SetScore(scoreManager.bestScore);

        Coins.TakeCoin.AddListener(TakeCoin);
        Obstacle.ObstacleTrigger.AddListener(ObstacleTrigger);
        EnergyPU.EnergyPickedUp.AddListener(EnergyPickedUp);
        SpeedPU.SpeedPickedUp.AddListener(SpeedPickedUp);
        playerFade.energyChanged.AddListener(EnergyChanged);
        gameOverUI.restartGame.AddListener(RestartGame);
        gameOverUI.mainMenu.AddListener(MainMenu);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void OnDestroy()
    {
        scoreManager.UpdateBestScore(playerController.score);

        Coins.TakeCoin.RemoveListener(TakeCoin);
        Obstacle.ObstacleTrigger.RemoveListener(ObstacleTrigger);
        EnergyPU.EnergyPickedUp.RemoveListener(EnergyPickedUp);
        SpeedPU.SpeedPickedUp.RemoveListener(SpeedPickedUp);
        playerFade.energyChanged.RemoveListener(EnergyChanged);
        gameOverUI.restartGame.RemoveListener(RestartGame);
        gameOverUI.mainMenu.RemoveListener(MainMenu);
    }

    private void OnApplicationQuit()
    {
        scoreManager.UpdateBestScore(playerController.score);
    }

    private void TakeCoin(int score)
    {
        playerController.AddScore(score);
        scoreUI.SetScore(playerController.score);
        if(playerController.score > scoreManager.bestScore)
        {
            bestScoreUI.SetScore(playerController.score);
        }
    }

    private void ObstacleTrigger(bool canFaded)
    {
        if(!canFaded || (canFaded && !playerController.isFaded))
        {
            GameOver();
        }
    }

    private void EnergyPickedUp(float energy)
    {
        playerController.AddEnergy(energy);
        energyUI.SetEnergy(playerController.energy);
    }

    private void SpeedPickedUp(float speed, float time)
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

    private void EnergyChanged(float energy)
    {
        energyUI.SetEnergy(energy);
        playerController.energy = energy;
    }

    private void GameOver()
    {
        SpeedUI.HideText();
        StopAllCoroutines();
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
        playerController.speed = speed;
        yield return new WaitForSeconds(time);
        playerController.setDefaultSpeed();
        SpeedUI.HideText();
        yield return null;
    }
}
