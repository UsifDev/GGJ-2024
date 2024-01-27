using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector2 jesterVel;
    private float speed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = 5f;
    }

    public void Update()
    {
        float movH = Input.GetAxis("Jester1H");
        jesterVel.x = movH * speed * Time.deltaTime;
        characterController.Move(jesterVel);
    }
}
