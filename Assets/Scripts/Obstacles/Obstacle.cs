using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static event Action<bool> ObstacleTrigger;
    [SerializeField] private bool canFaded = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObstacleTrigger(canFaded);
        }
    }
}
