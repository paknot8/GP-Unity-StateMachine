using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementScript : MonoBehaviour
{
    Rigidbody RigidBody;
    public float baseSpeed = 3;
    public float speedMultiplier = 2;
    public float jumpForce = 7;
    private bool jump = false;
    private bool isGrounded;

    // Bewegen van het object naar voren en achter en zuikant.
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Smooth movement of WASD and arrow keys
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movement = new Vector3(x, 0, z);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            movement *= baseSpeed + speedMultiplier;
        } 
        else
        {
            movement *= baseSpeed;
        }
        if(Input.GetKey(KeyCode.Space))
        {

            isGrounded = RigidBody.velocity.y == 0; // check if it hits the ground
            if(isGrounded == true){
                jump = true;
                RigidBody.velocity = new Vector3 (RigidBody.velocity.x, jumpForce, RigidBody.velocity.y * Time.deltaTime);
            }
        }

        transform.Translate(movement * baseSpeed * Time.deltaTime); 
    } 
    
}
