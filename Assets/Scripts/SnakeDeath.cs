using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDeath : MonoBehaviour
{
    [SerializeField] private float _numOfNonTriggeredParts;
    [SerializeField] private SnakeMovement _snake;

    private void Awake()
    {
        GameEvents.OnGameOver += GameOver;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bounds") || (_snake.bodyParts.Count > _numOfNonTriggeredParts && other.CompareTag("BodyPart")))
        {
            GameEvents.GameOver();
        }
    }

    private void GameOver()
    {
        _snake.startedGame = false;
    }

    private void OnDestroy()
    {
        GameEvents.OnGameOver -= GameOver;
    }
}
