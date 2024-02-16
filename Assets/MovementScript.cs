using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementScript : MonoBehaviour
{
    Rigidbody RigidBodyPlayer;
    public float baseSpeed = 3;
    public float speedMultiplier = 2;
    public float jumpForce = 7;
    public float gravity = -10;
    private bool isOnGround;

    // Bewegen van het object naar voren en achter en zuikant.
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        RigidBodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovements();
    }

    void PlayerMovements()
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
            if(RigidBodyPlayer.velocity.y == 0) // check if it hits the ground (Check if rigidbody is in contact with other collider) (IF TRUE)
            {
                //RigidBody.velocity = new Vector3 (RigidBody.velocity.x, jumpForce, RigidBody.velocity.y * Time.deltaTime);
                RigidBodyPlayer.velocity = new Vector3 (RigidBodyPlayer.velocity.x, jumpForce, RigidBodyPlayer.velocity.y * Time.deltaTime);
                Physics.gravity = new Vector3(0,gravity,0);
            }
        }
        transform.Translate(movement * baseSpeed * Time.deltaTime); 
        //RigidBody.velocity = new Vector3(x,0,y);
    } 
    
}
