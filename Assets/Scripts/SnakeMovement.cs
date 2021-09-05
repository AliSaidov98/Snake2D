using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField]
    private float _minDistance = 0.25f;
    [SerializeField]
    private int _beginSize;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _rotationSpeed = 10;

    private float _dis;
    private Transform _curBodyPart;
    private Transform _prevBodyPart;

    private Rigidbody _rb;
    private Vector3 _pos;
    private Camera _cam;
    private Vector2 _mousePosition;
    private Vector3 _lookAt;
    private Transform _head;
    
    public GameObject bodyprefabs;
    public List<Transform> bodyParts = new List<Transform>();
    public bool startedGame;
    
    private void Awake()
    {
        _cam = Camera.main;
        _head = bodyParts[0];

        GameEvents.OnGameStarted += StartMovement;
    }

    private void StartMovement()
    {
        startedGame = true;
    }
    
    private void FixedUpdate()
    {
        if(!startedGame) return;
        
        Move();
    }

    private void Move()
    {
        _head.position = Vector2.Lerp(_head.position, _head.position + _head.right * _speed, Time.deltaTime);
        
        Rotate();
        MoveBodyParts(_speed);
    }

    private void MoveBodyParts(float curspeed)
    {
        for (int i = 1; i < bodyParts.Count; i++)
        {
            _curBodyPart = bodyParts[i];
            _prevBodyPart = bodyParts[i - 1];

            _dis = Vector3.Distance(_prevBodyPart.position, _curBodyPart.position);

            Vector3 newpos = _prevBodyPart.position;

            float T = Time.deltaTime * _dis / _minDistance * curspeed;

            if (T > 0.5f)
                T = 0.5f;
            
            _curBodyPart.position = Vector3.Lerp(_curBodyPart.position, newpos, T);
            _curBodyPart.rotation = Quaternion.Lerp(_curBodyPart.rotation, _prevBodyPart.rotation, T);
        }
    }

    private void Rotate()
    {
        _mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        
        _lookAt.z = 0;
        _lookAt = Vector3.Slerp(_lookAt, _mousePosition - (Vector2)_head.position, Time.deltaTime * _rotationSpeed);
        
        _head.right = _lookAt;
    }

    private void OnDestroy()
    {
        GameEvents.OnGameStarted -= StartMovement;
    }
}
