using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimateObjects : MonoBehaviour
{
    [SerializeField] private Transform[] _eyesToAnimate;
    [SerializeField] private float _maxScaleAdd;
    [SerializeField] private float _animDuration;
    
    private void Awake()
    {
        Animate();
    }

    private void Animate()
    {
        foreach (var eye in _eyesToAnimate)
        {
            eye.DOScale(eye.localScale + Vector3.one * _maxScaleAdd, _animDuration).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
