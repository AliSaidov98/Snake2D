using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _headOfSnake;
    private Vector3 _newPos;
    
    private void Update()
    {
        _newPos = _headOfSnake.position;
        _newPos.z = transform.position.z;
        transform.position = _newPos;
    }
}
