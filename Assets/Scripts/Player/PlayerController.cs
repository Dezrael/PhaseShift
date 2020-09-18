using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;

    public int score;
    public float energy;
    public bool isFaded;
    public bool isMoving;
    public bool canJump;

    private void Awake()
    {
        score = 0;
        energy = 100.0f;
        isFaded = false;
        isMoving = true;
        canJump = true;
    }

    public void addScore(int amount)
    {
        score += amount;
    }

    public void addEnergy(float amount)
    {
        energy = energy + amount < 100 ? energy + amount : 100;
    }

    public void changeEnergy(float amount)
    {
        energy = amount;
    }
}
