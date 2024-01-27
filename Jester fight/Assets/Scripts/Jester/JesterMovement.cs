using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 jesterVel;
    public float speed = 20f;
    public float maxSpeed = 5f;
    public float jumpHeight = 20f;

    private string jName; // either Jester1 or Jester2 bruh

    private bool onGround;
    public float gravity = 9.8f;
    public LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onGround = true;
        jName = gameObject.name;
    }


    // Move in the horizontal axis
    private void MoveH()
    {
        float movH = Input.GetAxis(jName + "H");
        jesterVel.x = movH * speed * Time.deltaTime;
    }

    // Jump
    private void Jump() 
    { 
        if(onGround)
        {
            if (Input.GetButton(jName + "J"))
            {
                onGround = false;
                jesterVel.y += jumpHeight * Time.deltaTime;
            }
        }
    }

    
    private void ApplyGravity()
    {
        if (!onGround)
        {
            jesterVel.y -= gravity * Time.deltaTime;
        }
        else
        {
            jesterVel.y = 0;
        }
    }

    private void CollisionGround()
    {
        if(rb.IsTouchingLayers(groundLayer))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    private void Limit(Vector2 v)
    {
        float x = 0;
        float y = 0;
        if (v.x > 0)
        {
            x = Mathf.Clamp(v.x, v.x, maxSpeed * Time.deltaTime);
        }
        else if (v.x < 0)
        {
            x = Mathf.Clamp(v.x, -maxSpeed * Time.deltaTime, v.x);
        }

        if (v.y > 0)
        {
            y = Mathf.Clamp(v.y, v.y, maxSpeed * Time.deltaTime);
        }
        else if (v.y < 0)
        {
            y = Mathf.Clamp(v.y, -maxSpeed * Time.deltaTime, v.y);
        }
    }


    // Makes the jester move
    public void Update()
    {
        CollisionGround();
        ApplyGravity();
        MoveH();
        Jump();
        rb.velocity += jesterVel;
    }
}
