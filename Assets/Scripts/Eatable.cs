using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class Eatable : MonoBehaviour
{
    [SerializeField] private GameObject _full;
    [SerializeField] private GameObject _eated;
    [SerializeField] private float _scaleMax;
    [SerializeField] private float _scaleDuration;

    public bool eatable = true;
    public int score;

    private void OnEnable()
    {
        Animate();
    }

    public void Eat(float time)
    {
        eatable = false;
        _full.SetActive(false);
        _eated.SetActive(true);
        
        Invoke(nameof(ResetEatable), time);
    }

    private void ResetEatable()
    {
        eatable = true;
        _full.SetActive(true);
        _eated.SetActive(false);
    }

    private void Animate()
    {
        transform.DOScale(transform.localScale + Vector3.one * _scaleMax, _scaleDuration).SetLoops(-1, LoopType.Yoyo);
    }

}
