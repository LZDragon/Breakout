
//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout
//Name: Eliza Majernik
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 04/01/2024
/////////////////////////////////////////////using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject brickParticle;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GameManager.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
