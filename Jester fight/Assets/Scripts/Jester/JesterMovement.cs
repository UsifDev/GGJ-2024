using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 jesterVel;
    public float speed = 5;
    public float maxSpeed = 1000f;
    public float jumpHeight = 100f;

    private string jName; // either Jester1 or Jester2

    private bool onGround;
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

    /*

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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }
    */


    // Makes the jester move
    public void Update()
    {
        MoveH();
        // Jump();
        rb.velocity = jesterVel;
        // rb.velocity = Limit(rb.velocity);
        Debug.Log(onGround + ", " + rb.velocity);
    }
}
