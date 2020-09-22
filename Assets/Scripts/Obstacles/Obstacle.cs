using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private bool canFaded = true;
    public static UnityEvent<bool> ObstacleTrigger = new UnityEvent<bool>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObstacleTrigger?.Invoke(canFaded);
        }
    }
}
