using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPU : MonoBehaviour
{
    [SerializeField] private float energy = 20f;
    public static event Action<float> EnergyPickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnergyPickedUp(energy);
            Destroy(gameObject);
        }
    }
}
