using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreUI : MonoBehaviour
{
    private Text bestScoreText;

    private void Awake()
    {
        bestScoreText = GetComponent<Text>();
    }

    public void SetScore(int score)
    {
        bestScoreText.text = string.Format("Best score: {0}", score);
    }
}
