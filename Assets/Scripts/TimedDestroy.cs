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

public class TimedDestroy : MonoBehaviour
{
    public float destroyTime;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
