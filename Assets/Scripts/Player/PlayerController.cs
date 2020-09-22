using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public int score = 0;
    [SerializeField] public float energy = 100.0f;
    [SerializeField] public bool isFaded = false;
    [SerializeField] public bool isMoving = true;
    [SerializeField] public bool canJump = true;
    [SerializeField] public float baseSpeed = 20.0f;
    [SerializeField] public float speed = 20.0f;

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void AddEnergy(float amount)
    {
        energy = energy + amount < 100 ? energy + amount : 100;
    }

    public void setDefaultSpeed()
    {
        speed = baseSpeed;
    }

    public void DisableCharacter()
    {
        gameObject.SetActive(false);
    }
}
