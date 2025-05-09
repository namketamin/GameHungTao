using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUI;
    public bool isGameOver = false;
    void Start()
    {
        UpdateScore();
        gameOverUI.SetActive(false);
    }
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text=score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
    public void PlayAgain()
    {
        isGameOver=false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
}
