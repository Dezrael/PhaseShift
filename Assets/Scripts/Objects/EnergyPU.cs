using UnityEngine;
using UnityEngine.Events;

public class EnergyPU : MonoBehaviour
{
    [SerializeField] private float energy = 20f;
    public static UnityEvent<float> EnergyPickedUp = new UnityEvent<float>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnergyPickedUp?.Invoke(energy);
            Destroy(gameObject);
        }
    }
}
