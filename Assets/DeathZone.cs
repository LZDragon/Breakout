using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GM.LoseLife();
    }

}
