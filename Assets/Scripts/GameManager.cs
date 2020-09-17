using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayerController playerController;
    [SerializeField] public ScoreUI scoreUI;
    [SerializeField] public EnergyUI energyUI;
    [SerializeField] public PlayerFade playerFade;

    private void Awake()
    {
        Coins.TakeCoin += TakeCoin;
        Obstacle.ObstacleTrigger += ObstacleTrigger;
        EnergyPU.EnergyPickedUp += EnergyPickedUp;
        playerFade.energyChanged += EnergyChanged;
    }

    private void OnDestroy()
    {
        Coins.TakeCoin -= TakeCoin;
        Obstacle.ObstacleTrigger -= ObstacleTrigger;
        EnergyPU.EnergyPickedUp -= EnergyPickedUp;
        playerFade.energyChanged -= EnergyChanged;
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
            playerController.Restart();
            scoreUI.SetScore(0);
        }
    }

    public void EnergyPickedUp(float energy)
    {
        playerController.addEnergy(energy);
        energyUI.SetEnergy(playerController.energy);
    }

    public void EnergyChanged(float energy)
    {
        energyUI.SetEnergy(energy);
        playerController.changeEnergy(energy);
    }
}
