using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;
    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(playerController.isMoving)
        {
            rigidbody.velocity = new Vector2(playerController.speed, rigidbody.velocity.y);
        }
    }
}
