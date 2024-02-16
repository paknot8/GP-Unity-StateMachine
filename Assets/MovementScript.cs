using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private Rigidbody RigidBody;
    public float baseSpeed;
    public float sprint;
    private float currentSpeed;
    private bool isMoving = false;

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
        if (Input.GetKey(KeyCode.LeftShift) && isMoving)
        {
            currentSpeed = baseSpeed + sprint;
            Debug.Log("Left shift is Pressed");
        }
        else if(isMoving)
        {
            currentSpeed = baseSpeed;
        }
        
    }

    void Movement()
    {
        // Zorgt voor een smooth movement voor de X and Z
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isMoving = true;
        // Bewegen van het object naar voren en achter en zuikant.
        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * baseSpeed * Time.deltaTime);

    }
}
