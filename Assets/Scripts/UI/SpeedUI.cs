using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUI : MonoBehaviour
{
    [SerializeField] private Text speedText;
    [SerializeField] private Text speedTime;

    private void Awake()
    {
        DisableText();
    }

    public void HideText()
    {
        DisableText();
    }

    public void SetText(string text, Color color, float time)
    {
        StopAllCoroutines();
        speedText.text = text;
        speedText.color = color;
        speedTime.color = color;
        StartCoroutine(SetTime(time));
        EnableText();
    }

    private void EnableText()
    {
        speedText.gameObject.SetActive(true);
        speedTime.gameObject.SetActive(true);
    }

    private void DisableText()
    {
        speedText.gameObject.SetActive(false);
        speedTime.gameObject.SetActive(false);
    }

    private IEnumerator SetTime(float time)
    {
        float timeRemaining = time;
        while (timeRemaining > 0)
        {
            speedTime.text = Convert.ToString(Math.Round(timeRemaining,2));
            timeRemaining -= Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
