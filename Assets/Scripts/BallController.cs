//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout
//Name: Eliza Majernik
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 04/01/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialVelocity = 600f;
    private Rigidbody rb;
    private bool ballInPlay;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !ballInPlay)
        {
            transform.parent = null; //unparents ball from paddle
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(initialVelocity,initialVelocity,0));
        }
    }
}
