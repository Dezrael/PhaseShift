using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFade : MonoBehaviour
{
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float energyLoss = 20;
    public event Action<float> energyChanged;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !playerController.isFaded)
        {
            if(playerController.energy > 0)
            {
                StartCoroutine("Fade");
            }
        }
    }

    private IEnumerator Fade()
    {
        playerController.isFaded = true;
        while (playerController.isFaded && playerController.energy > 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            energyChanged(Mathf.Max(playerController.energy - energyLoss * Time.deltaTime, 0));
            yield return null;
            if (Input.GetKeyDown(KeyCode.M))
            {
                playerController.isFaded = false;
            }
        }
        playerController.isFaded = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);
        yield return null;
    }
}
