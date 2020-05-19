using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.01f, 1f)] [SerializeField] float speedAcceleration = 0.1f; // sets rate of increase over time
    [Range(10f, 100f)] [SerializeField] float initialSpeed = 10; // determines inital speed
    [SerializeField] int pointsPerBlock = 100;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText; //display score
    [SerializeField] bool autoPlayEnabled;

    private void Awake()
    {
        int gameStatusCounts = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCounts > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = speedAcceleration * (Time.fixedTime + initialSpeed);
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool AutoPlayEnabled()
    {
        return autoPlayEnabled;
    }
}
