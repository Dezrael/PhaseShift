using UnityEngine;
using UnityEngine.Events;

public class SpeedPU : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float time;
    public static UnityEvent<float, float> SpeedPickedUp = new UnityEvent<float, float>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpeedPickedUp?.Invoke(speed, time);
            Destroy(gameObject);
        }
    }
}
