using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action RanOut;

    [SerializeField] private float _duration = 7;

    public float Progress => _time / _duration;

    private bool _countTime;
    private float _time;

    private void Update()
    {
        if (!_countTime)
        {
            return;
        }

        _time += Time.deltaTime;

        if (_time >= _duration)
        {
            RanOut?.Invoke();
            Stop();
        }
    }

    public void StartCount()
    {
        _time = 0;
        _countTime = true;
    }

    public void Stop()
    {
        _countTime = false;
    }
}
