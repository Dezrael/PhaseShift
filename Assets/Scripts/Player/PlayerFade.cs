using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFade : MonoBehaviour
{
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float energyLoss = 20;
    [SerializeField] private float fadeAlpha = 0.4f;
    [SerializeField] private float normalAlpha = 1;
    public event Action<float> energyChanged;
    private KeyCode fadeKey = KeyCode.M;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(fadeKey) && !playerController.isFaded)
        {
            if(playerController.energy > 0)
            {
                StartCoroutine(Fade());
            }
        }
    }

    private IEnumerator Fade()
    {
        playerController.isFaded = true;
        while (playerController.isFaded && playerController.energy > 0)
        {
            spriteRenderer.color = ChangeAlpha(spriteRenderer.color, fadeAlpha);
            energyChanged(Mathf.Max(playerController.energy - energyLoss * Time.deltaTime, 0));
            yield return null;
            if (Input.GetKeyDown(fadeKey))
            {
                playerController.isFaded = false;
            }
        }
        playerController.isFaded = false;
        spriteRenderer.color = ChangeAlpha(spriteRenderer.color, normalAlpha);
        yield return null;
    }

    private Color ChangeAlpha(Color color, float opacity)
    {
        return new Color(color.r, color.g, color.b, opacity);
    }
}
