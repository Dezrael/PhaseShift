using UnityEngine;

public class SaveScore
{
    static public void Save(string key, int score)
    {
        PlayerPrefs.SetInt(key, score);
    }
}
