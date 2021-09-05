using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void GameEventsHandler();
    
    public static event GameEventsHandler OnGameOver;
    public static event GameEventsHandler OnGameStarted;

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public static void StartGame()
    {
        OnGameStarted?.Invoke();
    }
}
