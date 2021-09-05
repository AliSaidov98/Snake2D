using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _startGamePanel;

    private void Awake()
    {
        GameEvents.OnGameOver += GameOver;
    }

    public void StartGame()
    {
        _startGamePanel.SetActive(false);
        GameEvents.StartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeScore(int score)
    {
        _scoreText.text = score.ToString(CultureInfo.InvariantCulture);
    }
    
    private void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvents.OnGameOver -= GameOver;
    }
}
