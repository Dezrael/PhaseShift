using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPU : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float time;
    public static event Action<float, float> SpeedPickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpeedPickedUp(speed, time);
            Destroy(gameObject);
        }
    }
}
