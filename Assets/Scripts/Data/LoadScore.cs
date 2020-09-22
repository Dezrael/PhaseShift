using System.IO;
using UnityEngine;

public class LoadScore
{
    static public int Load(string key)
    {
        if(PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        return 0;
    }
}