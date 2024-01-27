using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector2 jesterVel;
    public float speed = 5f;
    public float jumpHeight = 1000f;

    private string jName; // either Jester1 or Jester2

    private bool onGround;
    private float gravity = 9.8f;
    private Ray ray;
    private RaycastHit raycastHit;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        onGround = true;
        jName = gameObject.name;
        ray = new Ray(transform.position, -transform.up);
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

    public void OnCollisionEnter(Collision collision)
    {
        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider.gameObject.name == "Platform")
            {
                onGround = true;
            }
        }
    }


    // Makes the jester move
    public void Update()
    {
        ApplyGravity();
        MoveH();
        Jump();
        characterController.Move(jesterVel);
    }
}
