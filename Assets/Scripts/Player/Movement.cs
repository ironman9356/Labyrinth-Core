using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    float horizontal;
    float vertical;
    public float speed = 12f;

    private void Start()
    {

    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, vertical) * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }


}