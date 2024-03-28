using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int lives = 3;
    private int level = 0;
    public int bricks;

    public float resetDelay = 1f;

    public TMP_Text livesText;

    public GameObject gameOver;

    public GameObject youWon;

    //public GameObject bricksPrefab;

    public GameObject paddle;

    private GameObject clonePaddle;
    private GameObject[] brickPrefabs;
    private GameObject currentBrickPattern;
    private void Awake()
    {
        brickPrefabs = Resources.LoadAll<GameObject>("BrickPatterns");
        CreateSingleton();
    }

    private void CreateSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Setup()
    {
        Debug.Log($"Loading level {level}");
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
        currentBrickPattern = Instantiate(brickPrefabs[level], transform.position, Quaternion.identity);
        bricks = brickPrefabs[level].transform.childCount;
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = 0.25f;
            NextLevel();

        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            lives = 3;
            level = 0;
            Invoke("Reset",resetDelay);
        }
    }

    void NextLevel()
    {
        if (level < brickPrefabs.Length - 1)
        {
            level++;
            lives++;
            Invoke("Reset", resetDelay);
        }
        else
        {
            youWon.SetActive(true);
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
        //SceneLoaded calls Setup

    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Pressed");
            NextLevel();
        }
    }
}
