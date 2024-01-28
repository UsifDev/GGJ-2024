using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 jesterVel;
    public float speed = 15f;
    public float maxHorSpeed = 5f;
    public bool onGround = false;

    private string jName; // either Jester1 or Jester2
    public LayerMask groundLayer;
    public Jester jester;

    public Vector2 facingright;
    public Vector2 facingleft;

    private void Start()
    {
        animator = JesterHand.animator;
        rb = GetComponent<Rigidbody2D>();
        jester = GetComponent<Jester>();
        jName = gameObject.name;

        facingleft = new Vector2(-transform.localScale.x, transform.localScale.y);
        facingright = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    private void Flip() 
    {
        if (jester.facing == "right")
        {
            transform.localScale = facingleft;
        }
        if (jester.facing == "left") 
        {
            transform.localScale = facingright;
        }
    }

    // Move in the horizontal axis
    private void MoveH()
    {
        float movH = Input.GetAxis(jName + "H");
        if (movH > 0)
        {
            jester.facing = "right";
            transform.localScale = facingright;
        }
        else if (movH < 0)
        {
            jester.facing = "left";
            transform.localScale = facingleft;
        }
        jesterVel.x = movH * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (onGround)
        {
            rb.AddForce(Vector2.up * 400);
        }
    }


    private Vector2 Limit(Vector2 v)
    {
        float x = v.x;
        if(v.x > maxHorSpeed)
        {  
            x = maxHorSpeed;
        }
        else if (v.x < -maxHorSpeed)
        {
            x = -maxHorSpeed;
        }

        if (x != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }

        return new Vector2 (x, v.y);
    }

    // Makes the jester move
    public void UpdateMove()
    {   
        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        MoveH();
        rb.velocity += jesterVel;
        rb.velocity = Limit(rb.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!onGround)
        {
            if (collision.gameObject.layer == 3)
            {
                onGround = true;
                animator.SetBool("isJumping", false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (onGround)
        {
            if (collision.gameObject.layer == 3)
            {
                onGround = false;
                animator.SetBool("isJumping", true);
            }
        }
    }
}
