using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    public void SetScore(int score)
    {
        scoreText.text = string.Format("Score: {0}", score);
    }
}
