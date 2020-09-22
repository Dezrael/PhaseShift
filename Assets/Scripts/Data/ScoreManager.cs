using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private string key = "best_score";
    public int bestScore;

    void Start()
    {
        bestScore = LoadScore.Load(key);
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateBestScore(int score)
    {
        if(score > bestScore)
        {
            bestScore = score;
            SaveScore.Save(key, bestScore);
        }
    }
}
