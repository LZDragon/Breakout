using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;

    public int bricks = 20;

    public float resetDelay = 1f;

    public TMP_Text livesText;

    public GameObject gameOver;

    public GameObject youWon;

    public GameObject bricksPrefab;

    public GameObject paddle;

    private GameObject clonePaddle;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset",resetDelay);
        }
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives:" + lives;
        Destroy(clonePaddle);
        Invoke("SetupPaddle",resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }

    private void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
