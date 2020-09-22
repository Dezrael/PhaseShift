using UnityEngine;

[CreateAssetMenu(fileName = "BestScore", menuName = "ScriptableObjects/BestScoreSO")]
public class ScoreManager : ScriptableObject
{
    [SerializeField] private string key = "best_score";
    public int bestScore;

    private void OnEnable()
    {
        bestScore = LoadScore.Load(key);
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
