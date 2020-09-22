using UnityEngine;
using UnityEngine.Events;

public class Coins : MonoBehaviour
{
    [SerializeField] private int score;
    public static UnityEvent<int> TakeCoin = new UnityEvent<int>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeCoin?.Invoke(score);
            Destroy(gameObject);
        }
    }
}
