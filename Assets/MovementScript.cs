using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private Rigidbody RigidBody;
    public float baseSpeed = 10;
    public float movementMultiplier = 2;
    private bool isSprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        // --- Basic ---
        // if(Input.GetKey(KeyCode.A))
        // {
        //     transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        // } 
        // else if (Input.GetKey(KeyCode.D))
        // {
        //     transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        // }
        // else if (Input.GetKey(KeyCode.W))
        // {
        //     transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        // }
        // else if (Input.GetKey(KeyCode.S))
        // {
        //     transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        // }
        // else if (Input.GetKey(KeyCode.Space))
        // {
        //     transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        // }
        Movement();
        
        
    }

    void Movement()
    {
        // Zorgt voor een smooth movement voor de X and Z, and unity weet dat GetAxis de input is van WASD
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
            // Bewegen van het object naar voren en achter en zuikant.
            Vector3 movement = new Vector3(x, 0, z);

            //movement = x * transform.right + z * transform.forward;

            if(isSprinting == true){
                movement *= movementMultiplier;
            }

            transform.Translate(movement * baseSpeed * Time.deltaTime);
    }
}
