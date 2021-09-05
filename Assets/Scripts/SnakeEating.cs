using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEating : MonoBehaviour
{
    [SerializeField] private float _timeToRespawnEatable;
    [SerializeField] private SnakeMovement _snake;
    [SerializeField] private UIHandler _ui;

    private int _scores;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Eatable")) return;
        
        var eatable = other.GetComponent<Eatable>();
        
        if(!eatable.eatable) return;

        eatable.Eat(_timeToRespawnEatable);

        _scores += eatable.score;
        
        _ui.ChangeScore(_scores);
        
        AddBodyPart(eatable.score);
    }

    private void AddBodyPart(int numOfParts)
    {
        for (int i = 0; i < numOfParts; i++)
        {
            var newBodyPart = Instantiate(_snake.bodyprefabs, _snake.bodyParts[_snake.bodyParts.Count - 1].position, Quaternion.identity).transform;

            newBodyPart.SetParent(_snake.transform);

            _snake.bodyParts.Add(newBodyPart);
        }
    }
}
