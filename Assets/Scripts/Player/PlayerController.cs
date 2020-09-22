using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score;
    public float energy;
    public bool isFaded;
    public bool isMoving;
    public bool canJump;
    public float baseSpeed;
    public float speed;

    private void Awake()
    {
        speed = baseSpeed = 20.0f;
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

    public void changeSpeed(float value)
    {
        speed = value;
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
