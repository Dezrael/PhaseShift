using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float jumpPower = 100f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
