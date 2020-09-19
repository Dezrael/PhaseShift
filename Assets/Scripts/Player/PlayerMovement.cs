using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if(playerController.isMoving)
        {
            transform.Translate(Vector2.right * playerController.speed * Time.deltaTime);
        }
    }
}
