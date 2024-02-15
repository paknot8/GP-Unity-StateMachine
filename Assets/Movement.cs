using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    float moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This is a test");
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

        // Zorgt voor een smooth movement voor de X and Z
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
