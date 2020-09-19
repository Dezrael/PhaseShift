using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUI : MonoBehaviour
{
    [SerializeField] private Text speedText;

    private void Awake()
    {
        speedText.gameObject.SetActive(false);
    }

    public void HideText()
    {
        speedText.gameObject.SetActive(false);
    }

    public void SetText(string text, Color color)
    {
        speedText.text = text;
        speedText.color = color;
        speedText.gameObject.SetActive(true);
    }
}
